using Microsoft.AspNetCore.Mvc;

namespace indoeuropean.Controllers
{
    [Route("blogs")]
    public class BlogsController : Controller
    {
<<<<<<< HEAD
        
=======
        [Route("europe")]
>>>>>>> cf1526ab6aa60f6509f241f503c504ce59378924
        public IActionResult Europeblog()
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
    }
}
