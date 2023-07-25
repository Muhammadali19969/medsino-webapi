using MedSino.DataAccess.ViewModels.Users;
using MedSino.Domain.Entities.Bookings;
using MedSino.Service.Dtos.Bookings;

namespace MedSino.Service.Interfaces.Bookings;

public interface IBookingService
{
    public Task<bool> CreateAsync(BookingCreateDto dto);

    public Task<IList<Booking>> GetByIdDateAsync(long id, string date);

    public Task<UserViewModel?> GetUserViewByDoctorIdDateTime(long doctorId,string time,string date);
}
