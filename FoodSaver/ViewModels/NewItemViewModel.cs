using FoodSaver.Models;
using Plugin.LocalNotifications;
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
        DateTime today = DateTime.Today;

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
            // Pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            // Parse the time and convert to useable string
            string tempTime = this.ExpirationTime.ToString();
            string[] timeArray = new string[10];
            timeArray = tempTime.Split(':');
            int hour = int.Parse(timeArray[0]);
            string amPm = "AM";

            // Check if its afternoon
            if(hour > 12)
            {
                hour = hour - 12;
                timeArray[0] = hour.ToString();
                amPm = "PM";
            }
            // Check if it is exactly noon
            else if (hour == 12)
            {
                timeArray[0] = hour.ToString();
                amPm = "PM";
            }
            // Check if it is exactly midnight
            else if (hour == 0)
            {
                timeArray[0] = "12";
                amPm = "AM";
            }

            tempTime = timeArray[0] + ":" + timeArray[1] + " " + amPm;

            // Store input in a new item object
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Food = this.Food,
                ExpirationDate = this.ExpirationDate.ToLongDateString(),
                ExpirationTime = tempTime
            };

            // Save the new item in the Firebase db
            await db.AddItem(newItem);

            // Calculate minutes until expiration time
            double minutes = 0.0;
            double minutesNow = (double)DateTime.Now.Minute;
            minutesNow += (double)DateTime.Now.Hour * 60;
            minutes = ExpirationTime.TotalMinutes - minutesNow;

            // Check if it expires on another day
            double daysTillExpiry = 0.0;
            if (ExpirationDate.ToShortDateString() != today.ToShortDateString())
            {
                double todayOA = today.ToOADate();
                double expiryOA = ExpirationDate.ToOADate();
                daysTillExpiry = expiryOA - todayOA;
                minutes += daysTillExpiry * 1440;   // Add 1440 minutes for each day                                                   
            }

            // Schedule Notification
            string msg = "The " + Food + " is expiring on " + ExpirationDate.ToLongDateString() + "!";
            CrossLocalNotifications.Current.Show(Food, msg, 101, DateTime.Now.AddMinutes(minutes));

            // Go back to the Items page
            await Shell.Current.GoToAsync("..");
        }
    }
}
