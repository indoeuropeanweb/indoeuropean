using Microsoft.AspNetCore.Mvc;

namespace indoeuropean.Controllers
{
    [Route("partners")]
    public class PartnersController : Controller
    {
     
        [Route("associate_agents")]
        public IActionResult Associate_Agents()
        {
            return View();
        }

        [Route("partner_franchise")]
        public IActionResult Partner_Franchise()
        {
            return View();
        }
        [Route("indian_universities")]
        public IActionResult Indian_Universities()
        {
            return View();
        }
        
        [Route("other_businesses")]
        public IActionResult Other_Businesses()
        {
            return View();
        }
        [Route("overseas_institute")]
        public IActionResult Overseas_Institute()
        {
            return View();
        }
      
    }
}
