using FoodSaver.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace FoodSaver.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private  string usernameCred = "GDSC";  //Hardcoded credientals 
        private string passwordCred = "Hackathon";

        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();

            Username.Text = Preferences.Get("UsernamePref", string.Empty);
            Password.Text = Preferences.Get("PasswordPref", string.Empty);
            RememberMe.IsToggled = Preferences.Get("RememberMe", true);

        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {

            if(Username.Text == null || Password.Text == null)
            {
                DisplayAlert("Looks like there is an error.","Please enter in username and password", "Let me try again");
            }
            else if(Username.Text.ToUpper() == usernameCred.ToUpper() && Password.Text == passwordCred && !RememberMe.IsToggled)
            {
                Application.Current.MainPage = new AppShell();
                Preferences.Clear();
            }
            else if (Username.Text.ToUpper() == usernameCred.ToUpper() && Password.Text == passwordCred && RememberMe.IsToggled)
            {
                Application.Current.MainPage = new AppShell();
                Preferences.Set("UsernamePref", Username.Text);
                Preferences.Set("PasswordPref", Password.Text);

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