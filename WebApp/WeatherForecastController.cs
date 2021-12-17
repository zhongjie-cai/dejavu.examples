using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApp
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IAct _actor;

        public WeatherForecastController(IAct actor)
        {
            _actor = actor;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var result = _actor.Get(
                DateTime.Now.Millisecond
            );
            return result;
        }
    }
}
