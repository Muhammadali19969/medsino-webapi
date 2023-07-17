namespace MedSino.Domain.Exceptions.HospitalDoctors;

public class HospitalDoctorNotFoundException : NotFoundException
{
    public HospitalDoctorNotFoundException()
    {
        this.TitleMessage = "HospitalDoctor not found !";
    }
}
