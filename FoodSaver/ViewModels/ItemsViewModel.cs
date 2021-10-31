using FoodSaver.Models;
using FoodSaver.Views;
using FoodSaver.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodSaver.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Item _selectedItem;

        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }
        public SortedList<double, Item> sortedByDate = new SortedList<double, Item>();

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Item>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            double date = 0.0;

            // Clear lists to prevent duplication
            Items.Clear();
            sortedByDate.Clear();

            try
            {
                // Sort the items
                // Get the list from db
                var getDB = await db.GetAllItems();
                // Add each item to the sorted list
                foreach (var item in getDB)
                {
                    // Get the expiry date and convert to OA date
                    DateTime oa = DateTime.Parse(item.ExpirationDate);
                    date = oa.ToOADate();
                    // Increment the date key to ensure no collisions
                    while (sortedByDate.ContainsKey(date))
                    {
                        date += 0.000000001;
                    }
                    sortedByDate.Add(date, item);
                }                
                                
                // Display the items in order of expiry dates
                foreach (var item in sortedByDate)
                { 
                    Items.Add(item.Value);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;            
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }


    }
}