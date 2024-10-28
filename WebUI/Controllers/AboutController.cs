using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AboutController : Controller
    {
        [HttpGet("hakkimizda")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
