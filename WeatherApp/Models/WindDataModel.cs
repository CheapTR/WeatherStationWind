using System;

namespace WeatherApp.Models
{
    public class WindDataModel
    {
        public DateTime DateTime { get; set; }
        public double MetrePerSec { get; set; }
        public double Direction { get; set; }

        public override string ToString()
        {
            return "DateTime: " + DateTime.ToString() + "\n Metres par seconde: " + MetrePerSec.ToString() + "\n Direction: " + Direction.ToString();
        }
    }
}
