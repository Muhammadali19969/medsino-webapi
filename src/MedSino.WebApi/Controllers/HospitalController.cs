using MedSino.DataAccess.Utils;
using MedSino.Service.Dtos.Hospitals;
using MedSino.Service.Interfaces.Hospitals;
using MedSino.Service.Validators.Dtos.Hospitals;
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
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] HospitalCreateDto dto)
    {
        var validator = new HospitalCreateValidator();
        var result = validator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpPut("{hospitalId}")]
    public async Task<IActionResult> UpdateAsync(long hospitalId, [FromForm] HospitalUpdateDto dto)
    {
        var validator = new HospitalUpdateValidator();
        var result = validator.Validate(dto);
        if (result.IsValid) return Ok(await _service.UpdateAsync(hospitalId, dto));
        else return BadRequest(result.Errors);

    }

    [HttpGet("{hospitalId}")]
    public async Task<IActionResult> GetByIdAsync(long hospitalId)
        => Ok(await _service.GetByIdAsync(hospitalId));

    [HttpDelete("{categoryId}")]
    public async Task<IActionResult> DeleteAsync(long categoryId)
        => Ok(await _service.DeleteAsync(categoryId));

}
