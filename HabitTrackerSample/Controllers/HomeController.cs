using Microsoft.AspNetCore.Mvc;

namespace HabitTrackerSample.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public string Get()
        {
            return "Hello and welcome to your C# and API test project!";
        }
    }
}
