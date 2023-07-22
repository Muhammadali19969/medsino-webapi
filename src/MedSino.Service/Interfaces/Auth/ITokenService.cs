using MedSino.Domain.Entities.Users;

namespace MedSino.Service.Interfaces.Auth;

public interface ITokenService
{
    public Task<string> GenerateToken(User user);
}
