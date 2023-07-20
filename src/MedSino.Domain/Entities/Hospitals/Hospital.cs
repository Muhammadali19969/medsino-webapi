namespace MedSino.Domain.Entities.Hospitals;

public class Hospital : Auditable
{
    public string Name { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string PhoneNum1 { get; set; } = string.Empty;
    public string PhoneNum2 { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;

}
