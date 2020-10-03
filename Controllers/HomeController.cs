using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YoYo_Web_App.Services;

namespace YoYo_Web_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var dataLoader = new DataLoader();
            return View(dataLoader.GetPlayersData());
        }

       
    }
}
