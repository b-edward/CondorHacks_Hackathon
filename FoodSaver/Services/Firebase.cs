//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Firebase.Database;
//using Firebase.Database.Query;
//using FoodSaver.Models;

//namespace FoodSaver.Helper
//{
//    public class Firebase
//    {
//        private readonly string ChildName = "Items";

//        readonly FirebaseClient firebase = new FirebaseClient("https://foodsaver-3798c-default-rtdb.firebaseio.com/");

//        public async Task<List<Item>> GetAllItems()
//        {
//            return (await firebase
//                .Child(ChildName)
//                .OnceAsync<Item>()).Select(item => new Item
//                {
//                    ItemId = item.Object.ItemId,
//                    Food = item.Object.Food,
//                    ExpirationDate = item.Object.ExpirationDate
//                }).ToList();
//        }

//        public async Task AddItem(string food, string expiration)
//        {
//            var rand = new Random();
//            await firebase
//                .Child(ChildName)
//                .PostAsync(new Item() { ItemId = rand.Next(0, sizeof(long)), Food = food, ExpirationDate = expiration });
//        }

//        public async Task<Item> GetItem(long id)
//        {
//            var allItems = await GetAllItems();
//            await firebase
//                .Child(ChildName)
//                .OnceAsync<Item>();
//            return allItems.FirstOrDefault(a => a.ItemId == id);
//        }

//        public async Task<Item> GetItem(string food)
//        {
//            var allItems = await GetAllItems();
//            await firebase
//                .Child(ChildName)
//                .OnceAsync<Item>();
//            return allItems.FirstOrDefault(a => a.Food == food);
//        }

//        public async Task UpdateItem(long id, string food, string expiry)
//        {
//            var toUpdateItem = (await firebase
//                .Child(ChildName)
//                .OnceAsync<Item>()).FirstOrDefault(a => a.Object.ItemId == id);

//            await firebase
//                .Child(ChildName)
//                .Child(toUpdateItem.Key)
//                .PutAsync(new Item() { ItemId = id, Food = food, ExpirationDate = expiry });
//        }

//        public async Task DeleteItem(long id)
//        {
//            var toDeleteItem = (await firebase
//                .Child(ChildName)
//                .OnceAsync<Item>()).FirstOrDefault(a => a.Object.ItemId == id);
//            await firebase.Child(ChildName).Child(toDeleteItem.Key).DeleteAsync();
//        }
//    }
//}