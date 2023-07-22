
namespace MedSino.Service.Dtos.Bookings;

public class BookingCreateDto
{
    public long UserId { get; set; }
    public long DoctorId { get; set; }
    public string StartTime { get; set; } = string.Empty;
    public string EndTime { get; set; } = string.Empty;
    public string BookingDate { get; set; } = string.Empty;
}
