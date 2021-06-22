using System;
using System.Collections.Generic;
using WeatherProjeckt.ViewModels;
using WeatherProjeckt.Views;
using Xamarin.Forms;

namespace WeatherProjeckt
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        
    }
}
