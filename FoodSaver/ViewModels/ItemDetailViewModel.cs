﻿using FoodSaver.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodSaver.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string food;
        private string expirationDate;
        public string Id { get; set; }

        public string Food
        {
            get => food;
            set => SetProperty(ref food, value);
        }

        public string ExpirationDate
        {
            get => expirationDate;
            set => SetProperty(ref expirationDate, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                // Get the item data from db
                LoadItemId(value);
            }
        }

        // Load the item
        public async void LoadItemId(string itemId)
        {
            try
            {
                // Find the item in the db and assign it to properties
                var item = await db.GetItem(itemId);
                Food = item.Food;
                ExpirationDate = item.ExpirationDate;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
