using Business.Abstract;
using Entity.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(UserForLoginDto userForLoginDto)
        {
            var userToLogin = await _authService.LoginAsync(userForLoginDto);
            if (!userToLogin.IsSuccess)
            {
                return BadRequest(userToLogin.Message);
            }
            var token = await _authService.CreateAccessTokenAsync(userToLogin.Data);
            if (!token.IsSuccess)
            {
                return BadRequest(token.Message);
            }
            return Ok(token.Data);

        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(UserForRegisterDto userForRegisterDto)
        {
            var userExists = await _authService.UserExistsAsync(userForRegisterDto.Email);
            if (!userExists.IsSuccess)
            {
                return BadRequest(userExists.Message);
            }
            var resultOfRegister = _authService.RegisterAsync(userForRegisterDto, userForRegisterDto.Password);
            var token = await _authService.CreateAccessTokenAsync(resultOfRegister.Result.Data);
            if (!token.IsSuccess)
            {
                return BadRequest(token.Message);
            }
            return Ok(token.Data);
        }
    }
}
