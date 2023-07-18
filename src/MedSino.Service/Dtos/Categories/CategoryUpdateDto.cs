using Microsoft.AspNetCore.Http;

namespace MedSino.Service.Dtos.Categories;

public class CategoryUpdateDto
{
    public string Name { get; set; } = string.Empty;

    public IFormFile? Image { get; set; }
}
