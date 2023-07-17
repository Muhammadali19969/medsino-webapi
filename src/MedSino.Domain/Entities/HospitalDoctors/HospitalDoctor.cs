namespace MedSino.Domain.Entities.HospitalDoctors;

public class HospitalDoctor : Auditable
{
    public long HospitalId { get; set; }
    public long DoctorId { get; set; }

}
