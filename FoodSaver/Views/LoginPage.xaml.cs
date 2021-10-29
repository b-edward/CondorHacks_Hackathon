using FoodSaver.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodSaver.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            string usernameCred = "Admin";
            string passwordCred = "Admin";

            if(Username.Text == usernameCred && Password.Text == passwordCred)
            {
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                DisplayAlert("Looks like there is an error","Username or password is incorrect", "Ok");
            }
        }

        private void RegisterTappedGesture(object sender, EventArgs e)
        {
            DisplayAlert("Registation Placeholder", "Username = Admin Password = Admin", "Ok");
        }



    }
}