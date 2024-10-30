using Microsoft.AspNetCore.Mvc;
using WebUI.Services.Abstract;

namespace WebUI.Controllers
{
    public class PsychologistController : Controller
    {
        private readonly IPsychologistService _psychologistService;

        public PsychologistController(IPsychologistService psychologistService)
        {
            _psychologistService = psychologistService;
        }

        [HttpGet("{psychologistUrl}")]
        public async Task<IActionResult> Index(string psychologistUrl)
        {
            var result = await _psychologistService.GetServiceByUrlAsync(psychologistUrl);
            return View(result);
        }

        [HttpGet("Ekibimiz")]
        public IActionResult OurCrew()
        {
            return View();
        }

    }
}
