using MedSino.DataAccess.Utils;
using MedSino.Domain.Entities.Users;
using MedSino.Service.Dtos.Users;

namespace MedSino.Service.Interfaces.Users;

public interface IUserService
{
    public Task<bool> UpdateAsync(long userId, UserUpdateDto dto);
    public Task<IList<User>> GetAllAsync(PaginationParams @params);

    public Task<User> GetByIdAsync(long userId);

    public Task<bool> DeleteAsync(long userId);
}
