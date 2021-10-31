using FoodSaver.Models;
using FoodSaver.ViewModels;
using FoodSaver.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodSaver.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();            
        }

        private async void OnAddItem(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }
    }
}