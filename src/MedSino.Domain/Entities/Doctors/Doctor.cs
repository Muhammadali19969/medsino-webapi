namespace MedSino.Domain.Entities.Doctors;

public class Doctor : Human
{
    public long CategoryId { get; set; }
    public string Address { get; set; } = string.Empty;
    public int WorkExperience { get; set; }
    public string Region { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string Fees { get; set; } = string.Empty;
    public string StartWorkTime { get; set; } = string.Empty;
    public string EndWorkTime { get; set; } = string.Empty;
    public string LunchTime { get; set; } = string.Empty;
}
