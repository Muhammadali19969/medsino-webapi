using Dapper;
using MedSino.DataAccess.Interfaces.Users;
using MedSino.DataAccess.Utils;
using MedSino.DataAccess.ViewModels.Users;
using MedSino.Domain.Entities.Users;

namespace MedSino.DataAccess.Repositories.Users;

public class UserRepository : BaseRepository, IUserRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select count(*) from users ";
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

    public async Task<int> CreateAsync(User entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.users( first_name, last_name, phone_num, image_path, password_hash, salt, created_at, updated_at, is_male, email, identity_role) " +
                "VALUES ( @FirstName, @LastName, @PhoneNumber, @ImagePath, @PasswordHash, @Salt, @CreatedAt, @UpdatedAt, @IsMail, @Email, @Role);";
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

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"delete from users where id = {id}";
            return await _connection.ExecuteAsync(query);
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
    public async Task<User?> GetByPhoneAsync(string phone)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM users where phone_num = @PhoneNumber";
            var user = await _connection.QuerySingleAsync<User>(query, new { PhoneNumber = phone });
            return user;
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

    public Task<IList<UserViewModel>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }


    public Task<UserViewModel?> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<(int ItemsCount, IList<UserViewModel>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, User entity)
    {
        throw new NotImplementedException();
    }
}


