using Dapper;
using MedSino.DataAccess.Interfaces.Doctors;
using MedSino.DataAccess.Utils;
using MedSino.DataAccess.ViewModels.Doctors;
using MedSino.Domain.Entities.Doctors;

namespace MedSino.DataAccess.Repositories.Doctors;

public class DoctorRepository : BaseRepository, IDoctorRepository
{
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<int> CreateAsync(Doctor entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Doctor>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<DoctorsViewModel?> GetByCategoryIdAsync(long categoryId)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"Select * from doctors_view where category_id = {categoryId}";
            var result = await _connection.QuerySingleAsync<DoctorsViewModel>(query);
            return result;
        }
        catch (Exception)
        {

            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<DoctorsViewModel?> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Doctor entity)
    {
        throw new NotImplementedException();
    }
}
