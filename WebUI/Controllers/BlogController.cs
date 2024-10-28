using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Services.Abstract;

namespace WebUI.Controllers
{

    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        [HttpGet("Blog-2")]
        public async Task<IActionResult> Index()
        {
            var result = await _blogService.GetAllAsync();
            return View(result);
        }

        [HttpGet("Blog/{blogUrl}")]
        public async Task<IActionResult> GetBlog(string blogUrl)
        {
            var result = await _blogService.GetBlogByUrlAsync(blogUrl);
            return View(result);
        }
    }
}
