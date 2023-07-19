using MedSino.Service.Dtos.Auth;
using MedSino.Service.Interfaces.Auth;
using MedSino.Service.Validators;
using MedSino.Service.Validators.Dtos.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedSino.WebApi.Controllers
{

    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            this._authService=authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromForm] RegisterDto dto)
        {
            var validator = new RegisterValidator();
            var result = validator.Validate(dto);
            if (result.IsValid)
            {
                var serviceResult = await _authService.RegisterAsync(dto);
                return Ok(new { serviceResult.Result, serviceResult.CachedMinutes });
            }
            else return BadRequest(result.Errors);
        }

        [HttpPost("register/send-code")]
        public async Task<IActionResult> SendCodeRegisterAsync(string email)
        {
            var result = EmailValidator.IsValidEmail(email);
            if (result == false) return BadRequest("Email is invalid!");

            var serviceResult = await _authService.SendCodeForRegisterAsync(email);
            return Ok(new { serviceResult.Result, serviceResult.CachedVerificationMinutes });
        }
    }
}
