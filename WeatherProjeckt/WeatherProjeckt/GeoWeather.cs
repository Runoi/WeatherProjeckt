using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using System.Windows.Input;
using System.Json;
using System.IO;
using Xamarin.Essentials;
using System.Threading;


namespace WeatherProjeckt
{
    public class CurrentWeather
    {
        public static async Task<string> Geo()
        {
            CancellationTokenSource cts;
            var request = new GeolocationRequest(GeolocationAccuracy.High);
            cts = new CancellationTokenSource();
            var location = await Geolocation.GetLocationAsync(request, cts.Token);
            string lat = Convert.ToString(location.Latitude);
            string lon = Convert.ToString(location.Longitude);

            string uri = "https://api.openweathermap.org/data/2.5/weather?lat=" + lat + "&lon=" + lon + "&cnt=1&appid=b16565b947de8534eaa8903a30b6ad5c&lang=ru&units=metric";
            string url = uri;
            return url;


        }
        public static async Task<string> Geo2()
        {
            CancellationTokenSource cts1;
            var request1 = new GeolocationRequest(GeolocationAccuracy.High);
            cts1 = new CancellationTokenSource();
            var location = await Geolocation.GetLocationAsync(request1, cts1.Token);
            string lat1 = Convert.ToString(location.Latitude);
            string lon1 = Convert.ToString(location.Longitude);

            string uri1 = "https://api.openweathermap.org/data/2.5/onecall?lat=" + lat1 + "&lon=" + lon1 + "&cnt=1&appid=b16565b947de8534eaa8903a30b6ad5c&lang=ru&units=metric";
            string url1 = uri1;
            return url1;
        }

    }
    public static class Parser
    {


        public static List<Temperature> Parse(string content)
        {
            JObject obj = JObject.Parse(content);
            var temps = new List<Temperature>();
            var days = obj["daily"];

            foreach (var day in days)
            {
                var t = new Temperature();
                var T = day["temp"];

                t.day = T["day"].Value<double>();
                t.min = T["min"].Value<double>();
                t.max = T["max"].Value<double>();
                t.night = T["night"].Value<double>();

                temps.Add(t);
            }
            return temps;
        }
    }

    public class Temperature
    {
        public double day;
        public double min;
        public double max;
        public double night;

    }
}
