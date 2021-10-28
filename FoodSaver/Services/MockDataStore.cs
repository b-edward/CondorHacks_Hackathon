//using FoodSaver.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace FoodSaver.Services
//{
//    public class MockDataStore : IDataStore<Item>
//    {
//        readonly List<Item> items;

//        public MockDataStore()
//        {
//            items = new List<Item>()
//            {
//                new Item { Id = Guid.NewGuid().ToString(), Text = "Bread", Description="November 1" },
//                new Item { Id = Guid.NewGuid().ToString(), Text = "Milk", Description="October 31" },
//                new Item { Id = Guid.NewGuid().ToString(), Text = "Cheese", Description="November 3" },
//                new Item { Id = Guid.NewGuid().ToString(), Text = "Chicken", Description="October 30" },
//                new Item { Id = Guid.NewGuid().ToString(), Text = "Yogourt", Description="November 4" },
//                new Item { Id = Guid.NewGuid().ToString(), Text = "Eggs", Description="November 7" },
//                new Item { Id = Guid.NewGuid().ToString(), Text = "Chips", Description="December 7" },
//                new Item { Id = Guid.NewGuid().ToString(), Text = "Pickles", Description="December 31" },
//                new Item { Id = Guid.NewGuid().ToString(), Text = "Kimchi", Description="January 27" },
//                new Item { Id = Guid.NewGuid().ToString(), Text = "Butter", Description="November 17" },
//            };
//        }

//        public async Task<bool> AddItemAsync(Item item)
//        {
//            items.Add(item);

//            return await Task.FromResult(true);
//        }

//        public async Task<bool> UpdateItemAsync(Item item)
//        {
//            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
//            items.Remove(oldItem);
//            items.Add(item);

//            return await Task.FromResult(true);
//        }

//        public async Task<bool> DeleteItemAsync(string id)
//        {
//            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
//            items.Remove(oldItem);

//            return await Task.FromResult(true);
//        }

//        public async Task<Item> GetItemAsync(string id)
//        {
//            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
//        }

//        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
//        {
//            return await Task.FromResult(items);
//        }
//    }
//}