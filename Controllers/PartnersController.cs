using Microsoft.AspNetCore.Mvc;

namespace indoeuropean.Controllers
{
    [Route("partners")]
    public class PartnersController : Controller
    {
     
        [Route("associateagents")]
        public IActionResult Associate_Agents()
        {
            return View();
        }

        [Route("partnerfranchise")]
        public IActionResult Partner_Franchise()
        {
            return View();
        }
        [Route("indianuniversities")]
        public IActionResult Indian_Universities()
        {
            return View();
        }
        
        [Route("otherbusinesses")]
        public IActionResult Other_Businesses()
        {
            return View();
        }
        [Route("overseasinstitute")]
        public IActionResult Overseas_Institute()
        {
            return View();
        }
      
    }
}
