using MedSino.Domain.Entities.Doctors;
using MedSino.Domain.Entities.Users;

namespace MedSino.Service.Interfaces.Auth;

public interface ITokenService
{
    public string GenerateToken(User user);
    public string GenerateDoctorToken(Doctor doctors);
}
