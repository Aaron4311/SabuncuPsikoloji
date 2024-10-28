
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using WebUI.Services.Abstract;

namespace WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMessageService _messageService;

        public ContactController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("iletisim")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("iletisim")]
        public async Task<IActionResult> Index(MessageModel model)
        {

            var result = await _messageService.AddMessageAsync(model);
            if (result)
            {
                return Ok(new { Message = "Mesajınız başarıyla alındı!" });

            }

            return View();
        }
    }
}
