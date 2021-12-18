using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public interface IManageWeatherForecast
    {
        IEnumerable<WeatherForecast> Get();
    }

    public class WeatherForecastManager : IManageWeatherForecast
    {
        private readonly IAct _actor;

        public WeatherForecastManager(IAct actor)
        {
            _actor = actor;
        }

        public IEnumerable<WeatherForecast> Get()
        {
            var result = _actor.Get(
                DateTime.Now.Millisecond
            );
            return result;
        }
    }
}
