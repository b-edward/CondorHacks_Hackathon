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
        private DateTime expirationDate;
        private TimeSpan expirationTime;

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
                && !(expirationDate == null)
                && !(expirationTime == null);
        }

        public string Food
        {
            get => food;
            set => SetProperty(ref food, value);
        }

        public DateTime ExpirationDate
        {
            get
            {
                // Set default value
                if(String.IsNullOrWhiteSpace(food))
                {
                    DateTime today = DateTime.Today;
                    expirationDate = today;
                }

                return expirationDate;
            }
            set => expirationDate = value;
        }

        public TimeSpan ExpirationTime
        {
            get => expirationTime;
            set => expirationTime = value;
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
            //string tempDate = this.ExpirationDate.ToLongDateString();
            //string[] dateArray = new string[10];
            //dateArray = tempDate.Split(',', ' ');

            string tempTime = this.ExpirationTime.ToString();
            string[] timeArray = new string[10];
            timeArray = tempTime.Split(':');
            int hour = int.Parse(timeArray[0]);
            string amPm = "AM";

            if(hour > 12)
            {
                hour = hour - 12;
                timeArray[0] = hour.ToString();
                amPm = "PM";
            }

            tempTime = timeArray[0] + ":" + timeArray[1] + " " + amPm;

            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Food = this.Food,
                ExpirationDate = this.ExpirationDate.ToLongDateString(),
                ExpirationTime = tempTime
            };

            //await DataStore.AddItemAsync(newItem);
            await db.AddItem(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
