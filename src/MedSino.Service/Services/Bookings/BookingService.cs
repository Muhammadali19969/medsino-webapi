using MedSino.DataAccess.Interfaces.Bookings;
using MedSino.DataAccess.ViewModels.Users;
using MedSino.Domain.Entities.Bookings;
using MedSino.Domain.Exceptions.Bookings;
using MedSino.Service.Common.Helpers;
using MedSino.Service.Dtos.Bookings;
using MedSino.Service.Interfaces.Bookings;

namespace MedSino.Service.Services.Bookings;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;

    public BookingService(IBookingRepository bookingRepository)
    {
        this._bookingRepository = bookingRepository;
        
    }

    public async Task<bool> CreateAsync(BookingCreateDto dto)
    {
        var booking = new Booking();
        booking.UserId = dto.UserId;
        booking.DoctorId = dto.DoctorId;
        booking.StartTime = dto.StartTime;
        booking.EndTime = dto.EndTime;
        booking.BookingDate = dto.BookingDate;
        booking.CreatedAt = booking.UpdatedAt = TimeHelper.GetDateTime();
        var result = await _bookingRepository.CreateAsync(booking);
        return result > 0;
    }

    public async Task<IList<Booking>> GetByIdDateAsync(long doctorId, string bookinDate)
    {
        var data = await _bookingRepository.GetByIdDateAsync(doctorId, bookinDate);
        return data;
    }

    public async Task<UserViewModel?> GetUserViewByDoctorIdDateTime(long doctorId, string time, string date)
    {
        var data = await _bookingRepository.GetUserViewByDoctorIdDateTimeAsync(doctorId, time, date);
        if (data == null) throw new BookingNotFoundException();
        return data;
    }
}
