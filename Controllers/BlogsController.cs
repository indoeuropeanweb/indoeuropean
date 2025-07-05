using Microsoft.AspNetCore.Mvc;

namespace indoeuropean.Controllers
{
    [Route("blogs")]
    public class BlogsController : Controller
    {

        [Route("europe")]
        public IActionResult Europeblog()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("latvia")]
        public IActionResult Latviablog()
        {
            return View();
        }
        [Route("studyabroad")]
        public IActionResult Studyabroadblog()
        {
            return View();
        }
        [Route("germany")]
        public IActionResult Germanyblog()
        {
            return View();
        }
        [Route("france")]
        public IActionResult Franceblog()
        {
            return View();
        }
        [Route("denmark")]
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
