using Microsoft.AspNetCore.Mvc;

namespace CORP.DiggRestProfil.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly Serilog.ILogger _logger = Serilog.Log.ForContext<WeatherForecastController>();

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [ResponseCache(Duration = 60)]
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.Information("Request {Port}", Request.Host.Port);

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.UtcNow,
                TemperatureC = 12,
                Summary = "Summary"
            })
            .ToArray();
        }

        [HttpPost(Name = "PostWeatherForecast")]
        public WeatherForecast Post()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.UtcNow,
                TemperatureC = 12,
                Summary = "Summary"
            })
            .ToArray().First();
        }
    }
}