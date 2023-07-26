using Dapper;
using MedSino.DataAccess.Interfaces.Users;
using MedSino.DataAccess.Utils;
using MedSino.DataAccess.ViewModels.Users;
using MedSino.Domain.Entities.Doctors;
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
            string query = "INSERT INTO public.users( first_name, last_name, phone_number, image_path, password_hash, salt, created_at, updated_at, is_male, email, identity_role) " +
                "VALUES ( @FirstName, @LastName, @PhoneNumber, @ImagePath, @PasswordHash, @Salt, @CreatedAt, @UpdatedAt, @IsMale, @Email, @IdentityRole);";
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
            string query = "SELECT * FROM users where phone_number = @PhoneNumber";
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


    public async Task<User?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM users where id=@Id";
            var result = await _connection.QuerySingleAsync<User>(query, new { Id = id });
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

    public Task<(int ItemsCount, IList<UserViewModel>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateAsync(long id, User entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE public.users SET first_name = @FirstName, last_name = @LastName, phone_number = @PhoneNumber, image_path = @ImagePath, " +
                " created_at = @CreatedAt, updated_at = @UpdatedAt, is_male = @IsMale, email = @Email " +
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


