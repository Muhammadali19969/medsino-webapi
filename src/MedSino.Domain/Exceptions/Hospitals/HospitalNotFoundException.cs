using System.Runtime.CompilerServices;

namespace MedSino.Domain.Exceptions.Hospitals;

public class HospitalNotFoundException : NotFoundException
{
    public HospitalNotFoundException()
    {
        this.TitleMessage = "Hospital not found !";
    }
}
