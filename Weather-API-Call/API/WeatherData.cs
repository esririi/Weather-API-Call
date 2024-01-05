using System;
using System.Collections.Generic;
using System.Text;

namespace API
{
    public class WeatherData
    {
        public bool success { get; set; }
        public string city { get; set; }
        public List<WeatherDetail> result { get; set; }
    }
}
