using FoodSaver.Services;
using FoodSaver.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//Headings and Titles
[assembly: ExportFont("OpenSans-Light.ttf", Alias = "OpenSansLight")]
[assembly: ExportFont("OpenSans-SemiBold.ttf", Alias = "OpenSansSemiBold")]
[assembly: ExportFont("OpenSans-Bold.ttf", Alias = "OpenSansBold")]
[assembly: ExportFont("OpenSans-Regular.ttf", Alias = "OpenSansReg")]

//Subtitles and Accents
[assembly: ExportFont("Nunito-Light.ttf", Alias ="NunitoLight")]
[assembly: ExportFont("Nunito-SemiBold.ttf", Alias = "NunitoBold")]
[assembly: ExportFont("Nunito-Regular.ttf", Alias = "NunitoReg")]




namespace FoodSaver
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
