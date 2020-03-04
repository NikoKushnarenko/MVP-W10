using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPTest.Models;
using UWPTest.Models.OpenWeatherMapAPI;

namespace UWPTest.Services
{
    public static class DataService
    {
        private static bool _isInitialized;
        public static MapperConfiguration Configuration { get; private set; }
        public static void Initialize()
        {
            if (!_isInitialized)
            {
                Configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<WheatherObj, WeatherInfo>()
                    .ForMember(x => x.Temp, x => x.MapFrom(m => m.Main.Temp))
                    .ForMember(x => x.Humidity, x => x.MapFrom(m => m.Main.Humidity))
                    .ForMember(x => x.Main, x => x.MapFrom(m => m.Weather.FirstOrDefault().Main))
                    .ForMember(x => x.Description, x => x.MapFrom(m => m.Weather.FirstOrDefault().Description))
                    .ForMember(x => x.Time, x => x.MapFrom(m => m.DtTxt));
                });
                _isInitialized = true;
            }
        }
    }
}
