using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using FoodSaver.Models;

namespace FoodSaver.Services
{
    public class FirebaseHelper
    {
        private readonly string ChildName = "Items";    // String to match category in realtime database

        // instantiate the connection to Google Firebase
        FirebaseClient firebase = new FirebaseClient("https://foodsaver-3798c-default-rtdb.firebaseio.com/");

        // Read all of the items in the db
        public async Task<List<Item>> GetAllItems()
        {
            // Put the items in a list and return it
            return (await firebase
                .Child(ChildName)
                .OnceAsync<Item>()).Select(item => new Item
                {
                    Id = item.Object.Id,
                    Food = item.Object.Food,
                    ExpirationDate = item.Object.ExpirationDate,
                    ExpirationTime = item.Object.ExpirationTime
                }).ToList();
        }

        // Create a new item in the database
        public async Task AddItem(Item newItem)
        {            
            await firebase
                .Child(ChildName)
                .PostAsync(new Item() { Id = newItem.Id, Food = newItem.Food, ExpirationDate = newItem.ExpirationDate, ExpirationTime = newItem.ExpirationTime });
        }

        // Read a single item from the database
        public async Task<Item> GetItem(string id)
        {
            var allItems = await GetAllItems();
            await firebase
                .Child(ChildName)
                .OnceAsync<Item>();
            return allItems.FirstOrDefault(a => a.Id == id);
        }

        // Update an item in the database
        public async Task UpdateItem(string id, string food, string date, string time)
        {
            // Find the item in the database
            var toUpdateItem = (await firebase
                .Child(ChildName)
                .OnceAsync<Item>()).FirstOrDefault(a => a.Object.Id == id);

            // Update the item in the database
            await firebase
                .Child(ChildName)
                .Child(toUpdateItem.Key)
                .PutAsync(new Item() { Id = id, Food = food, ExpirationDate = date, ExpirationTime = time });
        }

        // Once we have date/time set up, call delete method for that item?
        // Allow checking off items as eaten, then delete from db?

        // Delete an item from the database
        public async Task DeleteItem(string id)
        {
            // Find the item
            var toDeleteItem = (await firebase
                .Child(ChildName)
                .OnceAsync<Item>()).FirstOrDefault(a => a.Object.Id == id);
            // Delete the item
            await firebase.Child(ChildName).Child(toDeleteItem.Key).DeleteAsync();
        }
    }
}