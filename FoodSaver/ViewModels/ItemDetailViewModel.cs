using FoodSaver.Models;
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
                LoadItemId(value);
            }
        }
            
        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
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
