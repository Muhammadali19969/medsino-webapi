namespace MedSino.Domain.Entities.Bookings;

public class Booking : Auditable
{
    public long UserId { get; set; }
    public long DoctorId { get; set; }
    public TimeOnly StrartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public DateOnly BookingDate { get; set; }
}
