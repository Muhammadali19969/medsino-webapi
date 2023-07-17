namespace MedSino.Domain.Exceptions.Bookings;

public class BookingNotFoundException : NotFoundException
{
    public BookingNotFoundException()
    {
        this.TitleMessage = "Booking not found !";
    }
}
