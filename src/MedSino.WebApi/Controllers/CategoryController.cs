using MedSino.DataAccess.Utils;
using MedSino.Service.Dtos.Categories;
using MedSino.Service.Interfaces.Categories;
using MedSino.Service.Validators.Dtos.Categories;
using Microsoft.AspNetCore.Mvc;

namespace MedSino.WebApi.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoryController : ControllerBase
{
    private ICategoryService _service;
    private readonly int maxPageSize = 30;

    public CategoryController(ICategoryService categoryService)
    {
        this._service = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("count")]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());


    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CategoryCreateDto dto)
    {
        var createValidator = new CategoryCreateValidator();
        var result = createValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }


    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetByIdAsync(long categoryId)
        => Ok(await _service.GetByIdAsync(categoryId));


    [HttpDelete("{categoryId}")]
    public async Task<IActionResult> DeleteAsync(long categoryId)
        => Ok(await _service.DeleteAsync(categoryId));


    [HttpPut("{categoryId}")]
    public async Task<IActionResult> UpdateAsync(long categoryId, [FromForm] CategoryUpdateDto dto)
    {
        var updateValidator = new CategoryUpdateValidator();
        var validationResult = updateValidator.Validate(dto);
        if (validationResult.IsValid) return Ok(await _service.UpdateAsync(categoryId, dto));
        else return BadRequest(validationResult.Errors);
    }
}


