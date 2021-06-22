using System.ComponentModel;
using WeatherProjeckt.ViewModels;
using Xamarin.Forms;

namespace WeatherProjeckt.Views
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