
using Dapper;
using MedSino.DataAccess.Interfaces.Hospitals;
using MedSino.DataAccess.Utils;
using MedSino.Domain.Entities.Hospitals;

namespace MedSino.DataAccess.Repositories.Hospitals;

public class HospitalRepository : BaseRepository, IHospitalRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select count(*) from hospitals";
            var result = await _connection.QuerySingleAsync<long>(query);
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

    public async Task<int> CreateAsync(Hospital entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.hospitals (name, image_path, description, phone_num1, phone_num2," +
                " address, region, district, created_at, updated_at) " +
                "VALUES ( @Name, @ImagePath, @Description, @PhoneNum1, @PhoneNum2, @Address, @Region, @District, @CreatedAt, @UpdatedAt);";
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

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"delete from hospitals where id = @Id";
            var result = await _connection.ExecuteAsync(query, new { Id = id });
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

    public async Task<IList<Hospital>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select * from hospitals " +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<Hospital>(query, @params)).ToList();
            return result;
        }
        catch (Exception)
        {

            return new List<Hospital>();
        }
    }

    public async Task<Hospital?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select * from hospitals where id = @Id";
            var result = await _connection.QuerySingleAsync<Hospital>(query, new { Id = id });
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

    public async Task<int> UpdateAsync(long id, Hospital entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE public.hospitals " +
                "SET  name=@Name, image_path=@ImagePath, description=@Description, phone_num1=@PhoneNum1, phone_num2=@PhoneNum2," +
                " address=@Address, region=@Region, district=@District, created_at=@CreatedAt, updated_at=@UpdatedAt " +
                $"WHERE id = {id};";
            var result = await _connection.ExecuteAsync(query, entity);
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
}
