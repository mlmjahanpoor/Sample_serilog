using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Sample_Serilog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Log.Logger.ForContext("C2", "your custom value").ForContext("C3", "Your ...").Warning("Moslem loged in to app");
            return Ok("Result is success!");
        }
    }
}