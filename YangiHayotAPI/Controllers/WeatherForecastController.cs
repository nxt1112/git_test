using Microsoft.AspNetCore.Mvc;

namespace YangiHayotAPI.Controllers
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
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("test")]
        public IActionResult Test()
        {
            //Console.WriteLine(Directory.Exists("wwwroot"));



            //1
            //FileInfo fileInfo = new FileInfo("test-file.txt");
            //fileInfo.Create();

            //2
            //System.IO.File.Create("document.txt");


            //3
            using (StreamWriter sw = new StreamWriter("boshqa-fayl.txt"))
            {
                sw.WriteLine("hello");

            }
                return Ok("done");
        }



    }
}
