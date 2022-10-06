using Blazor.Modals;
using Microsoft.AspNetCore.Components;
namespace BlazorFrontEnd.Pages
{
    public partial class UserSingle
    {
        [Parameter]
        public int? Id { get; set; }
        string btnText = string.Empty;

        User user = new User { Commic = new Comic() };

        protected override async Task OnInitializedAsync()
        {
            btnText = Id == null ? "Save new" : "Update";
            await UserServices.GetComic();
        }
        protected async override Task OnParametersSetAsync()
        {
            if (Id == null)
            {
                user.Commic = UserServices.Comics[0];
                user.ComicId = user.Commic.Id;
            }
            else
            {
                user = await UserServices.GetSingleUser((int)Id);
            }
        }
        async Task HandleSubmit()
        {
            if(Id == null)
            {
                await UserServices.CreateUser(user);
            } else
            {
                await UserServices.UpdateUser(user);          
            }
        }
        async Task Deleteuser()
        { 
            await UserServices.DeleteUser(user.Id);
            
        }
        void WayBackHome ()
        {
            Navigation.NavigateTo("/userpage");
        }
       
    }
}
