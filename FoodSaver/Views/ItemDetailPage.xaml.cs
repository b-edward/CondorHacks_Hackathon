using FoodSaver.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace FoodSaver.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}