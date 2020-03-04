using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPTest.Models
{
    class WeatherInfo
    {
        public float Temp { get; set; }
        public float Humidity { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }

    }
}
