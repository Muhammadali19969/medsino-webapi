namespace MedSino.DataAccess.ViewModels.Doctors;

public class DoctorsViewModel
{
    public long DoctorId { get; set; }
    public long CategoryId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public int WorkExperience { get; set; }
    public string Region { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string StartWorkTime { get; set; } = string.Empty;
    public string EndWorkTime { get; set; } = string.Empty;
    public string LunchTime { get; set; } = string.Empty;
    public bool IsMale { get; set; }
    public float Fees { get; set; }
    public float Star { get; set; }


}
