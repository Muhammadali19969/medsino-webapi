using MedSino.DataAccess.Common.Interfaces;
using MedSino.DataAccess.ViewModels.Users;
using MedSino.Domain.Entities.Users;

namespace MedSino.DataAccess.Interfaces.Users;

public interface IUserRepository : IRepository<User, User>,
    IGetAll<User>, ISearchable<UserViewModel>
{
    public Task<User?> GetByPhoneAsync(string phone);

}
