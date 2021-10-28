using FoodSaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodSaver.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Food = "Bread", ExpirationDate="November 1" },
                new Item { Id = Guid.NewGuid().ToString(), Food = "Milk", ExpirationDate="October 31" },
                new Item { Id = Guid.NewGuid().ToString(), Food = "Cheese", ExpirationDate="November 3" },
                new Item { Id = Guid.NewGuid().ToString(), Food = "Chicken", ExpirationDate="October 30" },
                new Item { Id = Guid.NewGuid().ToString(), Food = "Yogourt", ExpirationDate="November 4" },
                new Item { Id = Guid.NewGuid().ToString(), Food = "Eggs", ExpirationDate="November 7" },
                new Item { Id = Guid.NewGuid().ToString(), Food = "Chips", ExpirationDate="December 7" },
                new Item { Id = Guid.NewGuid().ToString(), Food = "Pickles", ExpirationDate="December 31" },
                new Item { Id = Guid.NewGuid().ToString(), Food = "Kimchi", ExpirationDate="January 27" },
                new Item { Id = Guid.NewGuid().ToString(), Food = "Butter", ExpirationDate="November 17" },
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}