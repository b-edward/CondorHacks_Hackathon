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
        private readonly string ChildName = "Items";

        FirebaseClient firebase = new FirebaseClient("https://foodsaver-3798c-default-rtdb.firebaseio.com/");

        public async Task<List<Item>> GetAllItems()
        {
            return (await firebase
                .Child(ChildName)
                .OnceAsync<Item>()).Select(item => new Item
                {
                    Id = item.Object.Id,
                    Food = item.Object.Food,
                    ExpirationDate = item.Object.ExpirationDate
                }).ToList();
        }

        //public async Task AddItem(string food, string expiration)
        //{
        //    var rand = new Random();
        //    await firebase
        //        .Child(ChildName)
        //        .PostAsync(new Item() { Id = "TEMP", Food = food, ExpirationDate = expiration });
        //}

        public async Task AddItem(Item newItem)
        {            
            await firebase
                .Child(ChildName)
                .PostAsync(new Item() { Id = newItem.Id, Food = newItem.Food, ExpirationDate = newItem.ExpirationDate });
        }

        public async Task<Item> GetItem(string id)
        {
            var allItems = await GetAllItems();
            await firebase
                .Child(ChildName)
                .OnceAsync<Item>();
            return allItems.FirstOrDefault(a => a.Id == id);
        }

        //public async Task<Item> GetItem(string food)
        //{
        //    var allItems = await GetAllItems();
        //    await firebase
        //        .Child(ChildName)
        //        .OnceAsync<Item>();
        //    return allItems.FirstOrDefault(a => a.Food == food);
        //}

        public async Task UpdateItem(string id, string food, string expiry)
        {
            var toUpdateItem = (await firebase
                .Child(ChildName)
                .OnceAsync<Item>()).FirstOrDefault(a => a.Object.Id == id);

            await firebase
                .Child(ChildName)
                .Child(toUpdateItem.Key)
                .PutAsync(new Item() { Id = id, Food = food, ExpirationDate = expiry });
        }

        public async Task DeleteItem(string id)
        {
            var toDeleteItem = (await firebase
                .Child(ChildName)
                .OnceAsync<Item>()).FirstOrDefault(a => a.Object.Id == id);
            await firebase.Child(ChildName).Child(toDeleteItem.Key).DeleteAsync();
        }
    }
}