using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace InterCareBackend
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }

        public string BigAss { get; set; }

        public void connectToDatabase()
        {
            
        }

    }
}
