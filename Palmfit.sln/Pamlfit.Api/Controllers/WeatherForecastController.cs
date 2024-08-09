using Microsoft.AspNetCore.Mvc;

namespace Pamlfit.Api.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformation("Get method called in WeatherForecastController");

            IEnumerable<WeatherForecast> forecasts;

            try
            {
                forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();

                _logger.LogDebug("Generated {Count} weather forecasts", forecasts.Count());
                foreach (var forecast in forecasts)
                {
                    _logger.LogDebug("Forecast: Date={Date}, TempC={TemperatureC}, Summary={Summary}",
                        forecast.Date, forecast.TemperatureC, forecast.Summary);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while generating weather forecasts");
                throw; // Re-throw the exception to ensure it propagates
            }

            return forecasts;
        }
    }
}
