using OpenWeatherAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class OpenWeatherService : IWindDataService
    {
        private OpenWeatherProcessor owp;

        public WindDataModel LastWindData;

        public OpenWeatherService(string apiKey)
        {
            owp = OpenWeatherProcessor.Instance;
            owp.ApiKey = apiKey;
        }

        public async Task<WindDataModel> GetDataAsync()
        {
            var currentWeather = await owp.GetCurrentWeatherAsync();
            var result = new WindDataModel
            {
                DateTime = DateTime.UnixEpoch.AddSeconds(currentWeather.DateTime),
                Direction = currentWeather.Wind.Deg,
                MetrePerSec = currentWeather.Wind.Speed
            };
            LastWindData = result;
            return result;
        }
    }
}
