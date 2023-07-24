using MedSino.Domain.Entities.Users;

namespace MedSino.Service.Interfaces.Auth;

public interface ITokenService
{
    public string GenerateToken(User user);
}
