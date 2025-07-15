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
            if (Request.Path == "/home/index")
            {
                ViewData["Title"] = "Main Page";
                return RedirectPermanent("/");
            }
            else
            {
                ViewData["Title"] = "Home Page";
            }
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        //[Route("index_new")]
        //public IActionResult Index_New()
        //{
        //    return View();
        //}

        [Route("testimonials")]
        public IActionResult Testimonials()
        {
            return View();
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("thankyou")]
        public IActionResult Thankyou()
        {
            return View();
        }

        [Route("termsandconditions")]
        public IActionResult Termsandconditions()
        {
            return View();
        }

        [Route("coaching_centres")]
        public IActionResult Coaching_Centres()
        {
            return View();
        }

        [Route("enquiry")]
        public IActionResult Enquiry()
        {
            return View();
        }

        [Route("coaching")]
        public IActionResult Coaching()
        {
            return View();
        }

        [Route("our_services")]
        public IActionResult Our_Services()
        {
            return View();
        }

        [Route("collaborate")]
        public IActionResult Collaborate()
        {
            return View();
        }
    
    }
}
