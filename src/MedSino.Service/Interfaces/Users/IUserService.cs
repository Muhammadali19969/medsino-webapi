using MedSino.Service.Dtos.Users;

namespace MedSino.Service.Interfaces.Users;

public interface IUserService
{
    public Task<bool> UpdateAsync(long userId, UserUpdateDto dto);
}
