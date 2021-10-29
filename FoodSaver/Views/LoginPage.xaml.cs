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
            string usernameCred = "Admin";  //Hardcoded credientals 
            string passwordCred = "Admin";


            if(Username.Text == null || Password.Text == null)
            {
                DisplayAlert("Looks like there is an error.","Please enter in username and password", "Let me try again");
            }
            else if(Username.Text.ToUpper() == usernameCred.ToUpper() && Password.Text == passwordCred)
            {
                Application.Current.MainPage = new AppShell();
            }
            else 
            {
                DisplayAlert("Looks like there is an error.", "Incorrect username or password", "I will try again");
            }

        }

        private void RegisterTappedGesture(object sender, EventArgs e)
        {
            DisplayAlert("Registation Placeholder", "Username = Admin\nPassword = Admin", "Let's go!");
        }



    }
}