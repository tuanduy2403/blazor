using Blazor.Modals;
using Microsoft.AspNetCore.Components;

namespace BlazorFrontEnd.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly HttpClient httpClient;
        private readonly NavigationManager navigationManager;

        public UserServices(HttpClient httpClient, NavigationManager navigationManager )
        {
            this.httpClient = httpClient;
            this.navigationManager = navigationManager;
        }
        public List<User> Users { get; set; } = new List<User>();
        public List<Comic> Comics { get; set; } = new List<Comic>();

        public async Task CreateUser(User user)
        {
            var result = await httpClient.PostAsJsonAsync("api/User", user);
            await Result(result);  
        }

        private async Task Result(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<User>>();
            Users = response;
            navigationManager.NavigateTo("userpage");
        }

        public async Task DeleteUser(int id)
        {
            var result = await httpClient.DeleteAsync($"api/User/{id}");
            await Result(result);
            
        }

        public async Task GetComic()
        {
            var result = await httpClient.GetFromJsonAsync<List<Comic>>("api/User/comic");
            if (result != null)
                Comics = result;
        }

        public async Task<User> GetSingleUser(int id)
        {
            var result = await httpClient.GetFromJsonAsync<User>($"/api/User/{id}");
            if (result != null) return result;
            throw new Exception("not found!");
        }

        public async Task GetUser()
        {
            var result = await httpClient.GetFromJsonAsync<List<User>>("/api/User");
            if (result != null)
                Users = result;
        }

        public async Task UpdateUser(User user)
        {
            var result = await httpClient.PutAsJsonAsync($"api/User/{user.Id}", user);
            await Result(result);
        }
    }
}
