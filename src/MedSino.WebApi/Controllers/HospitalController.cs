using MedSino.DataAccess.Utils;
using MedSino.Service.Dtos.Hospitals;
using MedSino.Service.Interfaces.Hospitals;
using MedSino.Service.Validators.Dtos.Hospitals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedSino.WebApi.Controllers;

[Route("api/hospitals")]
[ApiController]
public class HospitalController : ControllerBase
{
    private readonly IHospitalService _service;
    private readonly int maxPageSize = 30;

    public HospitalController(IHospitalService service)
    {
        this._service = service;
    }


    [HttpGet("count")]
    [Authorize(Roles = "User,Admin")]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] HospitalCreateDto dto)
    {
        var validator = new HospitalCreateValidator();
        var result = validator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpPut("{hospitalId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync(long hospitalId, [FromForm] HospitalUpdateDto dto)
    {
        var validator = new HospitalUpdateValidator();
        var result = validator.Validate(dto);
        if (result.IsValid) return Ok(await _service.UpdateAsync(hospitalId, dto));
        else return BadRequest(result.Errors);

    }

    [HttpGet("get/{hospitalId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetByIdAsync(long hospitalId)
        => Ok(await _service.GetByIdAsync(hospitalId));

    [HttpDelete("{hospitalId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long categoryId)
        => Ok(await _service.DeleteAsync(categoryId));

}
