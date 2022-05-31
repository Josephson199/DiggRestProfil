using Dapper;
using DiggRestProfil.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

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
        private readonly IUnitOfWork _unitOfWork;

        public WeatherForecastController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

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
        public async Task<Guid> Post()
        {
            try
            {
                var id = Guid.NewGuid();

                await _unitOfWork.Connection.OpenAsync();

                await _unitOfWork.BeginAsync();

                _ = await _unitOfWork.Connection.ExecuteAsync(
                    @"INSERT INTO lab_reports(id)
                    VALUES
                    (@id);", new { id });

                await _unitOfWork.CommitAsync();

                await _unitOfWork.Connection.CloseAsync();

                return id;
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}