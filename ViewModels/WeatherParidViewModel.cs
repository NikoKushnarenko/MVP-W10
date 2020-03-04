using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPTest.Models;
using UWPTest.Models.OpenWeatherMapAPI;

namespace UWPTest.ViewModels
{
    class WeatherParidViewModel
    {
        public string Cod { get; set; }
        public string Message { get; set; }
        public int Cnt { get; set; }
        public IEnumerable<WheatherObj> List { get; set; }
    }
}
