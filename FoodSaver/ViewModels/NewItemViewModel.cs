using FoodSaver.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FoodSaver.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string food;
        private string expirationDate;
        private string expirationTime;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(food)
                && !String.IsNullOrWhiteSpace(expirationDate);
        }

        public string Food
        {
            get => food;
            set => SetProperty(ref food, value);
        }

        public string ExpirationDate
        {
            get => expirationDate;
            set => SetProperty(ref expirationDate, value.ToString());
        }

        public string ExpirationTime
        {
            get => expirationTime;
            set => SetProperty(ref expirationTime, value.ToString());
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Food = this.Food,
                ExpirationDate = this.ExpirationDate,
                ExpirationTime = this.ExpirationTime
            };

            //await DataStore.AddItemAsync(newItem);
            await db.AddItem(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
