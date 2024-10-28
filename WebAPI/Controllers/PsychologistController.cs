using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PsychologistController : ControllerBase
    {
        private readonly IPsychologistService _psychologistService;
        public PsychologistController(IPsychologistService psychologistService)
        {
            _psychologistService = psychologistService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _psychologistService.GetAllAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result.Data);
        }


        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _psychologistService.GetAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result.Data);
        }


        [HttpGet("GetByUrl/{psychologistUrl}")]
        public async Task<IActionResult> Get(string psychologistUrl)
        {
            var result = await _psychologistService.GetPsychologistByUrl(psychologistUrl);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result.Data);
        }

        [HttpPost("Add")]
        //[Authorize]
        public async Task<IActionResult> Add(Psychologist psychologist)
        {
            var result = await _psychologistService.AddAsync(psychologist);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result.Message);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(Psychologist psychologist)
        {
            var result = await _psychologistService.UpdateAsync(psychologist);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result.Message);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _psychologistService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result.Message);
        }
    }
}
