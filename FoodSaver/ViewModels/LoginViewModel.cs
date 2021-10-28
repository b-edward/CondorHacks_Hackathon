using FoodSaver.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodSaver.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked()
        {
            Application.Current.MainPage = new AppShell();

            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
