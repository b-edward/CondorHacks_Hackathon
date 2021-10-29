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
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
        }

        private  void LogoutButton_Clicked(object sender, EventArgs e)
        {
            //Go to login page 
            
            Application.Current.MainPage = (new LoginPage());
        }
       
    }
}