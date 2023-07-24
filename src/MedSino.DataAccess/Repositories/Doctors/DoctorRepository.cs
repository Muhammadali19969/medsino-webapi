using Dapper;
using MedSino.DataAccess.Interfaces.Doctors;
using MedSino.DataAccess.Utils;
using MedSino.DataAccess.ViewModels.Doctors;
using MedSino.Domain.Entities.Categories;
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

    public async Task<long> CreateAsync1(Doctor entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.doctors( category_id, first_name, last_name, address, phone_num, email, image_path, work_experience, region, district, start_work_time, end_work_time, lunch_time, password_hash, salt, created_at, updated_at, is_male, fees, identity_role) " +
                "VALUES ( @CategoryId, @FirstName, @LastName, @Address, @PhoneNumber, @Email, @ImagePath, @WorkExperience, @Region, @District, @StartWorkTime, @EndWorkTime, @LunchTime, @PasswordHash, @Salt, @CreatedAt, @UpdatedAt, @IsMale, @Fees, @IdentityRole) " +
                "RETURNING ID;";
            var result = await _connection.ExecuteAsync(query,entity);
            return (long) result;
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

    public Task<int> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Doctor>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<DoctorsViewModel>?> GetByCategoryIdAsync(long categoryId)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $" Select * from doctors_view where category_id = {categoryId} ";
            var result = (await _connection.QueryAsync<DoctorsViewModel>(query)).ToList();
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

    public async Task<Doctor?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM doctors where id=@Id";
            var result = await _connection.QuerySingleAsync<Doctor>(query, new { Id = id });
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

    public async Task<int> UpdateAsync(long id, Doctor entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE public.doctors " +
                "SET first_name=@FirstName, last_name=@LastName, address=@Address, phone_num=@PhoneNumber, email=@Email, image_path=@ImagePath, work_experience=@WorkExperience, region=@Region, district=@District, start_work_time=@StartWorkTime, end_work_time=@EndWorkTime, lunch_time=@LunchTime, created_at=@CreatedAt, updated_at=@UpdatedAt, is_male=@IsMail, fees=@Fees " +
                $"WHERE id = {id}";
            var result = await _connection.ExecuteAsync(query, entity);
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
