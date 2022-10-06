
using Blazor.Modals;

namespace BlazorFrontEnd.Services.UserServices
{
    public interface IUserServices
    {
        List<User> Users { get; set; }
        List<Comic> Comics { get; set; }
        Task GetComic();
        Task GetUser();
        Task<User> GetSingleUser(int id);

        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int id);
    }
}
