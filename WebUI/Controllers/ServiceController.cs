using Microsoft.AspNetCore.Mvc;
using WebUI.Services.Abstract;

namespace WebUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        [HttpGet("/hizmetlerimiz/{serviceUrl}")]
        public async Task<IActionResult> Index(string serviceUrl)
        {
            var result = await _serviceService.GetServiceByUrl(serviceUrl);
            return View(result);
        }
    }
}
