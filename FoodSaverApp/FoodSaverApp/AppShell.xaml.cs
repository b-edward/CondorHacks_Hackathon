using FoodSaverApp.ViewModels;
using FoodSaverApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FoodSaverApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
