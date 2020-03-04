using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPTest.Models.OpenWeatherMapAPI
{
    public class WheatherObj
    {
        public long Dt { get; set; }
        public Information Main { get; set; }
        public IEnumerable<Weather> Weather { get; set; }
        public Clouds Clouds { get; set; }
        public Wind Wind { get; set; }
        public Sys Sys { get; set; }
        [JsonProperty("dt_txt")]
        public DateTime DtTxt { get; set; }
    }
}
