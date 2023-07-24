using Microsoft.AspNetCore.Http;

namespace MedSino.Service.Dtos.Doctors;

public class DoctorCreateDto
{
    public long CategoryId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public IFormFile? Image { get; set; }
    public bool IsMale { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int WorkExperience { get; set; }
    public string Region { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public float Fees { get; set; }
    public string StartWorkTime { get; set; } = string.Empty;
    public string EndWorkTime { get; set; } = string.Empty;
    public string LunchTime { get; set; } = string.Empty;
}
