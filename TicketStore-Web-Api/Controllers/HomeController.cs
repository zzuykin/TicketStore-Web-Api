

using Microsoft.AspNetCore.Mvc;
namespace TicketStore_Web_Api.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        public HomeController()
        { 
        
        }

        [HttpGet,Route("")]
        public ActionResult Index() { return View(); }
    }
}
