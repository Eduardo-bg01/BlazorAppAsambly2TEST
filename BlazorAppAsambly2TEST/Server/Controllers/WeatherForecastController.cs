using BlazorAppAsambly2TEST.Shared;
using Microsoft.AspNetCore.Mvc;
using BlazorAppAsambly2TEST.Client.Shared;

namespace BlazorAppAsambly2TEST.Server.Controllers
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

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("/kelvin")]
        public IEnumerable<WeatherForecast> Kelvin()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55) + 273,
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("/kelvin/{numero}/{coco}")]

        public string Kelvin(long numero, string coco)
        {
            return "Tu numero de la suerte es: " + numero + ", buen dia " + coco;
        }

        [HttpPost("/op")]
        public operaciones operaciones(operaciones operacionToDo)
        {
            switch (operacionToDo.OperacionAritmetica)
            {
                case "suma":
                    operacionToDo.Res = operacionToDo.NumeroA + operacionToDo.NumeroB;
                    break;
                case "resta":
                    operacionToDo.Res = operacionToDo.NumeroA - operacionToDo.NumeroB;
                    break;
                case "multiplicacion":
                    operacionToDo.Res = operacionToDo.NumeroA * operacionToDo.NumeroB;
                    break;
                case "division":
                    operacionToDo.Res = operacionToDo.NumeroA / operacionToDo.NumeroB;
                    break;
            }
            return operacionToDo;
        }
    }
}
