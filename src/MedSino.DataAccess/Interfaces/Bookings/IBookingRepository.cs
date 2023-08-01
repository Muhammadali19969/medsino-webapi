using MedSino.DataAccess.ViewModels.Users;
using MedSino.Domain.Entities.Bookings;

namespace MedSino.DataAccess.Interfaces.Bookings;

public interface IBookingRepository
{
    public Task<int> CreateAsync(Booking booking);
    public Task<IList<Booking>> GetByIdDateAsync(long id, string date);
    public Task<UserViewModel?> GetUserViewByDoctorIdDateTimeAsync(long doctorId, string time, string date);

}
