using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Library.Controllers
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
            return View();
        }

        public IActionResult Author()
        {
            return View("~/Views/Home/Author/Author.cshtml");
        }
        
        public IActionResult Publisher()
        {
            return View("~/Views/Home/Publisher/Publisher.cshtml");
        }
        
        public IActionResult Book()
        {
            return View("~/Views/Home/Book/Book.cshtml");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}