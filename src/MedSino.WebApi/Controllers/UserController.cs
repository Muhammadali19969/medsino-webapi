using MedSino.Service.Dtos.Doctors;
using MedSino.Service.Dtos.Users;
using MedSino.Service.Interfaces.Users;
using MedSino.Service.Validators.Dtos.Doctors;
using MedSino.Service.Validators.Dtos.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedSino.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService=userService;
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateAsync(long userId, [FromForm] UserUpdateDto dto)
        {
            var updateValidator = new UserUpdateValidator();
            var validationResult = updateValidator.Validate(dto);
            if (validationResult.IsValid) return Ok(await _userService.UpdateAsync(userId, dto));
            else return BadRequest(validationResult.Errors);
        }

    }
}
