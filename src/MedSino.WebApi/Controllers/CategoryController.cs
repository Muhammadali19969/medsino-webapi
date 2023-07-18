using MedSino.DataAccess.Utils;
using MedSino.Domain.Entities.Categories;
using MedSino.Service.Dtos;
using MedSino.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

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
    public async Task<IActionResult> GetAllAsync([FromForm] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("count")]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetByIdAsync(long categoryId, CategoryUpdateDto dto)
        => Ok(await _service.GetByIdAsync(categoryId));
    
}
