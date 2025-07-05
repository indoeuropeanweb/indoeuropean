using Microsoft.AspNetCore.Mvc;

namespace indoeuropean.Controllers
{
    public class BlogsController : Controller
    {
        
        public IActionResult Europeblog()
        {
            return View();
        }
        public IActionResult latviablog()
        {
            return View();
        }
        public IActionResult studyabroadblog()
        {
            return View();
        }
        public IActionResult germanyblog()
        {
            return View();
        }
        public IActionResult franceblog()
        {
            return View();
        }
        public IActionResult denmarkblog()
        {
            return View();
        }
    }
}
