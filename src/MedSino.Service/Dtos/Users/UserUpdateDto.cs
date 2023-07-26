using Microsoft.AspNetCore.Http;

namespace MedSino.Service.Dtos.Users;

public class UserUpdateDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public IFormFile? Image { get; set; }
    public bool IsMale { get; set; }
    public string Email { get; set; } = string.Empty;
}
