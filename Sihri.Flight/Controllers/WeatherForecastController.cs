using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sihri.Flight.Models;
using Sihri.Infrastructure.Interfaces;

namespace Sihri.Flight.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly ICacheService cacheService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICacheService cacheService)
        {
            _logger = logger;
            this.cacheService = cacheService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<FlightWeatherForecast> Get()
        {

            cacheService.SetAsync("asd", "asd").GetAwaiter().GetResult();
            return Enumerable.Range(1, 5).Select(index => new FlightWeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}