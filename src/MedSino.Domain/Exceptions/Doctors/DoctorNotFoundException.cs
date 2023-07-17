namespace MedSino.Domain.Exceptions.Doctors;

public class DoctorNotFoundException : NotFoundException
{
    public DoctorNotFoundException()
    {
        this.TitleMessage = "Doctor not found !";
    }
}
