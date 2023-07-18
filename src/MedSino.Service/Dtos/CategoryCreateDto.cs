using Microsoft.AspNetCore.Http;

namespace MedSino.Service.Dtos;

public class CategoryCreateDto
{
    public string Name { get; set; } = string.Empty;

    public IFormFile ImagePath { get; set; } = default!;
}
