using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Sample_Serilog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Log.Logger.ForContext("C2", "your custom value").ForContext("C3", "Your ...").Information("Moslem loged in to app");
            return Ok("Result is success!");
        }
    }
}