using Microsoft.AspNetCore.Mvc;

namespace indoeuropean.Controllers
{
    [Route("destinations")]
    public class DestinationsController : Controller
    {
        [Route("europe")]
        public IActionResult Europe()
        {
            return View();
        }

        [Route("usa")]
        public IActionResult Usa()
        {
            return View();
        }

        [Route("australia")]
        public IActionResult Australia()
        {
            return View();
        }

        [Route("canada")]
        public IActionResult Canada()
        {
            return View();
        }

        [Route("new_zealand")]
        public IActionResult New_Zealand()
        {
            return View();
        }

        [Route("singapore")]
        public IActionResult Singapore()
        {
            return View();
        }

        [Route("uk")]
        public IActionResult Uk()
        {
            return View();
        }

        [Route("ireland")]
        public IActionResult Ireland()
        {
            return View();
        }
        [Route("finland")]
        public IActionResult Finland()
        {
            return View();
        }
        [Route("germany")]
        public IActionResult Germany()
        {
            return View();
        }



    }
}
