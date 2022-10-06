using Blazor.Modals;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;

namespace BlazorFrontEnd.Pages
{
    public partial class UserPage
    {
        protected bool isOpenAddButton = false;
        protected string? valueCss = "d-none";
        protected override async Task OnInitializedAsync()
        {
            await UserServices.GetUser();
        }


        protected void handleOpenAddButton()
        {
            isOpenAddButton = !isOpenAddButton;
        }
        protected void ShowUser(int id)
        {
            Navigation.NavigateTo($"user/{id}");
        }

        void CreateNewUser()
        {
            Navigation.NavigateTo("user");
        }

    }
}
