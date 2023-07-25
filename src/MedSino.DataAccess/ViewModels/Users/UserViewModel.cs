namespace MedSino.DataAccess.ViewModels.Users;

public class UserViewModel
{
    public long UserId { get; set; }
    public long DoctorId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Start_Time { get; set; } = string.Empty;
    public string End_Time { get; set; } = string.Empty;
    public string Booking_Date { get; set; } = string.Empty;
}
