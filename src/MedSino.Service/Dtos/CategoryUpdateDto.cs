using Microsoft.AspNetCore.Http;

namespace MedSino.Service.Dtos;

public class CategoryUpdateDto
{
    public string Name { get; set; } = String.Empty;

    public IFormFile? Image { get; set; }
}
