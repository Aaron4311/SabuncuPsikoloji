using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderContentController : ControllerBase
    {
        private readonly ISliderContentService _sliderContentService;

        public SliderContentController(ISliderContentService sliderContentService)
        {
            _sliderContentService = sliderContentService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _sliderContentService.GetAllAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result.Data);
        }


        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _sliderContentService.GetAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result.Data);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(SliderContent sliderContent)
        {
            var result = await _sliderContentService.AddAsync(sliderContent);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result.Message);
        }
        [HttpPut("Update")]

        public async Task<IActionResult> Update(SliderContent sliderContent)
        {
            var result = await _sliderContentService.UpdateAsync(sliderContent);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result.Message);
        }
        [HttpDelete("Delete/{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _sliderContentService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result.Message);
        }
    }
}
