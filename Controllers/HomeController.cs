using indoeuropean.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
namespace indoeuropean.Controllers
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

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Index_New()
        {
            return View();
        }

        public IActionResult Testimonials()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Title"] = "Contact";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Thankyou()
        {
            return View();
        }

        public IActionResult Termsandconditions()
        {
            return View();
        }
    }
}
