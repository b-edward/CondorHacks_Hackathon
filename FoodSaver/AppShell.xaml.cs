using FoodSaver.ViewModels;
using FoodSaver.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Firebase.Database;
using Firebase.Database.Query;
using FoodSaver.Services;
using FoodSaver.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FoodSaver
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        // Instantiate an object to interact with Firebase
        private FirebaseHelper db = new FirebaseHelper();
        DateTime today = DateTime.Today;
        public DateTime ExpDate;
        string itemsExpiring = "";

        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            OnLoad();
        }

        public async void OnLoad()
        {
            // Get the db and build a string 
            await GetItems();

            // Check if there are items expiring soon
            if (itemsExpiring != "")
            {
                // Display reminder of items expiring in the next 2 days
                await Application.Current.MainPage.DisplayAlert("Foods expiring in less than 2 days!", itemsExpiring, "OK");
             }
       }

        public async Task GetItems()
        {
            try
            {
                var items = await db.GetAllItems();
                foreach (var item in items)
                {
                    ExpDate = DateTime.Parse(item.ExpirationDate);
                    double todayOA = today.ToOADate();
                    double expiryOA = ExpDate.ToOADate();                    
                    // Save the items expiring in less than 2 days
                    if ((expiryOA - todayOA) <= 2)
                    {
                        itemsExpiring += item.Food + "\n";
                    }                         
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
