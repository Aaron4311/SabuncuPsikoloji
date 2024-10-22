using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _blogService.GetAllAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result.Data);
        }


        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _blogService.GetAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result.Data);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(Blog blog)
        {
            var result = await _blogService.AddAsync(blog);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result.Message);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(Blog blog)
        {
            var result = await _blogService.UpdateAsync(blog);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result.Message);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _blogService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result.Message);
        }
    }
}
