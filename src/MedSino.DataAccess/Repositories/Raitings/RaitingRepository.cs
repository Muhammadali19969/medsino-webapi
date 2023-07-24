using Dapper;
using MedSino.DataAccess.Interfaces.Raitings;
using MedSino.Domain.Entities.Raitings;
using System.ComponentModel;

namespace MedSino.DataAccess.Repositories.Raitings;

public class RaitingRepository : BaseRepository, IRaitingRepository
{
    public async Task<long> CreateAsync(Raiting raiting)
    {
		try
		{
			await _connection.OpenAsync();
			string query = "INSERT INTO public.raitings(doctor_id, user_id, star_count, created_at, updated_at) " +
                "VALUES ( @DoctorId, @UserId, @StarCount, @CreatedAt, @UpdatedAt);";
			var result = await _connection.ExecuteAsync(query, raiting);
			return result;

        }
		catch (Exception)
		{

			return 0;
		}
		finally
		{
			await _connection.CloseAsync();
		}
    }
}
