using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherProjeckt.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherProjeckt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CuWePage : ContentPage
    {
        public CuWePage()
        {
            InitializeComponent();
            this.BindingContext = new CityViewModel();
        }
    }
}