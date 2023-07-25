using Dapper;
using MedSino.DataAccess.Interfaces.Bookings;
using MedSino.DataAccess.ViewModels.Users;
using MedSino.Domain.Entities.Bookings;
using MedSino.Domain.Entities.Categories;
using MedSino.Domain.Entities.Doctors;
using static Dapper.SqlMapper;

namespace MedSino.DataAccess.Repositories.Bookings;

public class BookingRepository : BaseRepository, IBookingRepository
{
    public async Task<int> CreateAsync(Booking booking)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.bookings(user_id, doctor_id, start_time, end_time, booking_date, created_at, updated_at) " +
                "VALUES (@UserId, @DoctorId, @StartTime, @EndTime, @BookingDate, @CreatedAt, @UpdatedAt);";
            var result = await _connection.ExecuteAsync(query, booking);
            return result;
        }
        catch 
        {

            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }


    public async Task<IList<Booking>> GetByIdDateAsync(long doctorId, string bookingDate)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select * from public.bookings where doctor_id = {doctorId} and booking_date = '{bookingDate}';";
            var result = (await _connection.QueryAsync<Booking>(query)).ToList();

            return result;
        }
        catch 
        {

            return new List<Booking>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<UserViewModel?> GetUserViewByDoctorIdDateTimeAsync(long doctoId, string time, string date)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select * from user_view where doctor_id = {doctoId} and booking_date = '{date}' and start_time = '{time}' ;";
            var result = await _connection.QuerySingleAsync<UserViewModel>(query);

            return result;
        }
        catch
        {

            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
