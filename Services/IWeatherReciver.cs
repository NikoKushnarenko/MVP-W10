using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPTest.Services
{
    interface IWeatherReciver
    {
        void GetForecastsCountry(string countryName);
        void GetForecastsCity(string cityName);
    }
}
