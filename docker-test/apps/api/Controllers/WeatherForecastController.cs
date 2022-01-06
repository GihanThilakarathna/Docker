using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
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
        public IEnumerable<Details> Get()
        {          
            DetailsContext context = HttpContext.RequestServices.GetService(typeof(api.Controllers.DetailsContext)) as DetailsContext;
            var detailslist = context.GetAllDetails();

            foreach (var item in detailslist)
            {
                if (item.temperatureC == 0)
                {
                    item.summary = "Cold";
                }
                else if (item.temperatureC < 0)
                {
                    item.summary = "Coldest";
                }
                else if (item.temperatureC > 0)
                {
                    item.summary = "Hot";
                }
                else if (item.temperatureC >= 100)
                {
                    item.summary = "Hottest";
                }

                else if (item.temperatureC == 37)
                {
                    item.summary = "Normal";
                }
                else
                {
                    item.summary = "No one";
                }
            }

            return detailslist;

        }
    }
}
