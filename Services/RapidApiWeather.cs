using AutoMapper;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPTest.Models;
using UWPTest.ViewModels;

namespace UWPTest.Services
{
    class OpenWeatherMapReciver : IWeatherReciver
    {
        readonly RestClient _client;
        readonly RestRequest _request;
        readonly IMapper mapper = DataService.Configuration.CreateMapper();
        public OpenWeatherMapReciver()
        {
            _client = new RestClient();
            _request = new RestRequest(Method.GET);
            _request.AddHeader("x-rapidapi-host", "community-open-weather-map.p.rapidapi.com");
            _request.AddHeader("x-rapidapi-key", "e6c39bd674msh9427aa6d899d158p11b835jsn6ec5d26c8942");
        }
        public void GetForecastsCountry(string countryName)
        {
            _client.BaseUrl = new Uri($"https://community-open-weather-map.p.rapidapi.com/forecast?q={countryName}");
            var response = _client.Execute(_request).Content;

            WeatherParidViewModel res = JsonConvert.DeserializeObject<WeatherParidViewModel>(response);
            var c = res.List.Select(x => mapper.Map<WeatherInfo>(x));

        }

        public void GetForecastsCity(string cityName)
        {
            _client.BaseUrl = new Uri($"https://community-open-weather-map.p.rapidapi.com/find?type=link%2C%20accurate&units=imperial%2C%20metric&q={cityName}");
            var response = _client.Execute(_request).Content;

            var res = JsonConvert.DeserializeObject<WeatherParidViewModel>(response);
            var c = res.List.Select(x => mapper.Map<WeatherInfo>(x));
        }



    }
}
