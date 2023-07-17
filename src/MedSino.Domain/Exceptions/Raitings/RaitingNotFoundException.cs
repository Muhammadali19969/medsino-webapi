namespace MedSino.Domain.Exceptions.Raitings;

public class RaitingNotFoundException : NotFoundException
{
    public RaitingNotFoundException()
    {
        this.TitleMessage = "Raiting not found !";
    }
}
