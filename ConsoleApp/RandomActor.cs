using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public interface IAct
    {
        IEnumerable<WeatherForecast> Get(int seed);
    }

    public class RandomActor : IAct
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecast> Get(int seed)
        {
            var rng = new Random(seed);
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}