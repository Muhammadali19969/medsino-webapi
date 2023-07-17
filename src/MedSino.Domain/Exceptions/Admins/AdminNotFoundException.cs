namespace MedSino.Domain.Exceptions.Admins;

public class AdminNotFoundException : NotFoundException
{
    public AdminNotFoundException()
    {
        this.TitleMessage = "Admin not found !";
    }
}
