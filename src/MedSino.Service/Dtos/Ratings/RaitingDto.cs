namespace MedSino.Service.Dtos.Ratings;

public class RaitingDto
{
    public long DoctorId { get; set; }
    public long UserId { get; set; }
    public float StarCount { get; set; }
}
