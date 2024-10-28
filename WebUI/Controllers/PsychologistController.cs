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

        //[HttpGet("uzman-psikolog-gizem-ozfuttu")]
        //public IActionResult GizemOzfuttu()
        //{
        //    return View();
        //}
        //[HttpGet("uzman-klinik-psikolog-merve-ozen")]
        //public IActionResult MerveOzen()
        //{
        //    return View();
        //}
        //[HttpGet("uzman-psikolog-aile-danismani-duygu-bakir")]
        //public IActionResult DuyguBakır()
        //{
        //    return View();
        //}
    }
}
