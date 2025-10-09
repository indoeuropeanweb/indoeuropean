using Microsoft.AspNetCore.Mvc;

namespace indoeuropean.Controllers
{
    [Route("blogs")]
    public class BlogsController : Controller
    {

        [Route("studyineurope")]
        public IActionResult Europeblog()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("studyinlatvia")]
        public IActionResult Latviablog()
        {
            return View();
        }
        [Route("studyabroadeurope")]
        public IActionResult Studyabroadblog()
        {
            return View();
        }
        [Route("studyingermany")]
        public IActionResult Germanyblog()
        {
            return View();
        }
        [Route("studyinfrance")]
        public IActionResult Franceblog()
        {
            return View();
        }
        [Route("studyindenmark")]
        public IActionResult Denmarkblog()
        {
            return View();
        }
        [Route("rigatechnicaluniversity")]
        public IActionResult Rigablog()
        {
            return View();
        }
    }
}
