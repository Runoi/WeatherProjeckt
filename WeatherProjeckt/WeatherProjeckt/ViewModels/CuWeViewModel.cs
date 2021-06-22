using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using System.Windows.Input;
using System.Json;
using System.IO;
using Xamarin.Essentials;
using System.Threading;
using WeatherProjeckt.Models;
using WeatherProjeckt.Services;

namespace WeatherProjeckt.ViewModels
{

    public class CityInfo
    {
        public string name { get; set; }
    }

    public class CityMain
    {
        public double temp { get; set; }
        public double feels_like { get; set; }

        public int pressure { get; set; }
        public int humidity { get; set; }
    }

    public class CityViewModel : CurrentWeather, INotifyPropertyChanged
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        private string Name;
        private double Temp;
        private double Feels_Like;

        private int Pressure;
        private int Humidity;



        public string name
        {
            get { return Name; }
            private set
            {
                Name = value;
                OnPropertyChanged("name");
                
            }


        }




        public double temp
        {
            get { return Temp; }
            private set
            {
                Temp = value;
                OnPropertyChanged("temp");
            }
        }

        public double feels_like
        {
            get { return Feels_Like; }
            private set
            {
                Feels_Like = value;
                OnPropertyChanged("feels_like");
            }
        }



        public int pressure
        {
            get { return Pressure; }
            private set
            {
                Pressure = value;
                OnPropertyChanged("pressure");
            }
        }

        public int humidity
        {
            get { return Humidity; }
            private set
            {
                Humidity = value;
                OnPropertyChanged("humidity");
            }
        }

        public ICommand LoadDataCommand { protected set; get; }

        public CityViewModel()
        {
            this.LoadDataCommand = new Command(LoadData);
        }
        public async void LoadData()
        {

            string url = await Geo();

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                var response = await client.GetAsync(client.BaseAddress);
                response.EnsureSuccessStatusCode(); // выброс исключения, если произошла ошибка

                // десериализация ответа в формате json
                var content = await response.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(content);

                var geo = o.SelectToken(@"$");
                var cityInfo = JsonConvert.DeserializeObject<CityInfo>(geo.ToString());

                var CityTemp = o.SelectToken(@"$.main");
                var CityTempInfo = JsonConvert.DeserializeObject<CityMain>(CityTemp.ToString());


                this.name = cityInfo.name;


                this.temp = CityTempInfo.temp;
                this.feels_like = CityTempInfo.feels_like;

                this.pressure = CityTempInfo.pressure;
                this.humidity = CityTempInfo.humidity;
            }
            catch (Exception ex)
            { }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
