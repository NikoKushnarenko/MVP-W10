﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPTest.Models.OpenWeatherMapAPI
{
    public class Information
    {
        public float Temp { get; set; }
        public float TempMin { get; set; }
        public float TempMax { get; set; }
        public float Pressure { get; set; }
        public float SeaLevel { get; set; }
        public float GrndLevel { get; set; }
        public int Humidity { get; set; }
        public int TempKf { get; set; }
    }
}
