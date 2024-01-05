using System;
using System.Collections.Generic;
using System.Text;

namespace API
{
    public class WeatherDetail
    {
        public string date { get; set; }
        public string day { get; set; }
        public string icon { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public float degree { get; set; }
        public float min { get; set; }
        public float max { get; set; }
        public float night { get; set; }
        public float humidity { get; set; }
    }
}
