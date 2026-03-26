using Microsoft.AspNetCore.Mvc;

namespace indoeuropean.Controllers
{
    [Route("destinations")]
    public class DestinationsController : Controller
    {
        [Route("study-in-europe")]
        public IActionResult Europe()
        {
            return View();
        }

        [Route("study-in-usa")]
        public IActionResult Usa()
        {
            return View();
        }

        [Route("study-in-australia")]
        public IActionResult Australia()
        {
            return View();
        }

        [Route("study-in-canada")]
        public IActionResult Canada()
        {
            return View();
        }

        [Route("study-in-newzealand")]
        public IActionResult New_Zealand()
        {
            return View();
        }

        [Route("study-in-singapore")]
        public IActionResult Singapore()
        {
            return View();
        }

        [Route("study-in-uk")]
        public IActionResult Uk()
        {
            return View();
        }

        [Route("study-in-ireland")]
        public IActionResult Ireland()
        {
            return View();
        }
        [Route("study-in-finland")]
        public IActionResult Finland()
        {
            return View();
        }
        [Route("study-in-germany")]
        public IActionResult Germany()
        {
            return View();
        }
        [Route("study-in-denmark")]
        public IActionResult Denmark()
        {
            return View();
        }
        [Route("study-in-lithuania")]
        public IActionResult Lithuania()
        {
            return View();
        }
        [Route("study-in-latvia")]
        public IActionResult Latvia()
        {
            return View();
        }
        [Route("study-in-france")]
        public IActionResult France()
        {
            return View();
        }
        [Route("study-in-sweden")]
        public IActionResult Sweden()
        {
            return View();
        }
    }
}
