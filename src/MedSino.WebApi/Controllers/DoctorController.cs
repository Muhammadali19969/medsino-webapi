using MedSino.Service.Dtos.Doctors;
using MedSino.Service.Interfaces.Doctors;
using MedSino.Service.Validators.Dtos.Doctors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedSino.WebApi.Controllers
{

    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {


        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            this._doctorService = doctorService;
        }

        [HttpGet("{categoryId}")]
        //[Authorize(Roles = "Doctor")]

        public async Task<IActionResult> GetByCategoryIdAsync(long categoryId)
            =>Ok(await _doctorService.GetByCategoryIdAsync(categoryId));

        [HttpPut("{doctorId}")]
        //[Authorize(Roles = "Doctor")]
        public async Task<IActionResult> UpdateAsync(long doctorId,[FromForm] DoctorUpdateDto dto)
        {
            var updateValidator = new DoctorUpdateValidator();
            var validationResult = updateValidator.Validate(dto);
            if (validationResult.IsValid) return Ok(await _doctorService.UpdateAsync(doctorId, dto));
            else return BadRequest(validationResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] DoctorCreateDto dto)
        {
            var createValidator = new DoctorCreateValidator();
            var validatorResult = createValidator.Validate(dto);
            if (validatorResult.IsValid) return Ok(await _doctorService.CreateAsync(dto));
            else return BadRequest(validatorResult.Errors);
        }


        
    }
}
