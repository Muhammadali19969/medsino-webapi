using FluentValidation;
using MedSino.DataAccess.Utils;
using MedSino.Service.Dtos.Doctors;
using MedSino.Service.Interfaces.Doctors;
using MedSino.Service.Validators.Dtos.Auth;
using MedSino.Service.Validators.Dtos.Doctors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedSino.WebApi.Controllers
{

    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {


        private readonly IDoctorService _doctorService;
        private readonly int maxPageSize = 30;

        public DoctorController(IDoctorService doctorService)
        {
            this._doctorService = doctorService;
        }

        [HttpGet("star/{categoryId}")]
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

        [HttpGet("search")]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> SearchAsync([FromQuery] string search)
            =>Ok(await _doctorService.SearchAsync(search));

        [HttpPost("doctorLogin")]
        public async Task<IActionResult> LoginAsync(DoctorLoginDto loginDto)
        {
            var validator = new DoctorLoginValidator();
            var valResult = validator.Validate(loginDto);
            if (valResult.IsValid == false) return BadRequest(valResult.Errors);

            var serviceResult = await _doctorService.LoginAsync(loginDto);
            return Ok(new { serviceResult.Result, serviceResult.Token });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok( await _doctorService.GetAllAsync(new PaginationParams(page, maxPageSize)));

        [HttpGet("{doctorId}")]
        public async Task<IActionResult> GetByIdAsync(long doctorId)
            => Ok(await _doctorService.GetByIdAsync(doctorId));




    }
}
