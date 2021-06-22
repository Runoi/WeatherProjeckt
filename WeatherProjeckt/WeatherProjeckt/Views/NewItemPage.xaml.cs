using System;
using System.Collections.Generic;
using System.ComponentModel;
using WeatherProjeckt.Models;
using WeatherProjeckt.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherProjeckt.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}