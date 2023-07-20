
using Microsoft.AspNetCore.Http;

namespace MedSino.Service.Dtos.Hospitals;

public class HospitalUpdateDto
{
    public string Name { get; set; } = string.Empty;
    public IFormFile? Image { get; set; }
    public string Description { get; set; } = string.Empty;
    public string PhoneNumber1 { get; set; } = string.Empty;
    public string PhoneNumber2 { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
}
