using Microsoft.AspNetCore.Mvc;

namespace indoeuropean.Controllers
{
    [Route("blogs")]
    public class BlogsController : Controller
    {

        [Route("study-in-europe")]
        public IActionResult Europeblog()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("study-in-latvia")]
        public IActionResult Latviablog()
        {
            return View();
        }
        [Route("studyabroad")]
        public IActionResult Studyabroadblog()
        {
            return View();
        }
        [Route("study-in-germany")]
        public IActionResult Germanyblog()
        {
            return View();
        }
        [Route("study-in-france")]
        public IActionResult Franceblog()
        {
            return View();
        }
        [Route("study-in-denmark")]
        public IActionResult Denmarkblog()
        {
            return View();
        }
        [Route("rtu")]
        public IActionResult Rigablog()
        {
            return View();
        }
    }
}
