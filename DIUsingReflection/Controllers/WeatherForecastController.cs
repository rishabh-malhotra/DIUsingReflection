using DIUsingReflection.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DIUsingReflection.Controllers
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
        private readonly ISingletonExample _singletonExample;
        private readonly ITransientExample _transientExample;
        private readonly IScopedExample _scopedExample;
        private readonly ISingletonExample2 _singletonExample2;
        private readonly ITransientExample2 _transientExample2;
        private readonly IScopedExample2 _scopedExample2;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, ISingletonExample singletonExample, 
                                            ITransientExample transientExample, IScopedExample scopedExample, ISingletonExample2 singletonExample2, 
                                            ITransientExample2 transientExample2, IScopedExample2 scopedExample2)
        {
            _logger = logger;
            _singletonExample = singletonExample;
            _transientExample = transientExample;
            _scopedExample = scopedExample;
            _singletonExample2 = singletonExample2;
            _transientExample2 = transientExample2;
            _scopedExample2 = scopedExample2;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                SingletonGuid = _singletonExample.DoSingletonWork(),
                ScopedGuid = _scopedExample.DoScopedWork(),
                TransientGuid = _transientExample.DoTransientWork(),
                SingletonGuid2 = _singletonExample2.DoSingletonWorkAgain(),
                ScopedGuid2 = _scopedExample2.DoScopedWorkAgain(),
                TransientGuid2 = _transientExample2.DoTransientWorkAgain()
            })
            .ToArray();
        }
    }
}
