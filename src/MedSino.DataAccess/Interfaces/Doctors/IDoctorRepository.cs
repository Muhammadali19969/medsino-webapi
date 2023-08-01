using MedSino.DataAccess.Common.Interfaces;
using MedSino.DataAccess.ViewModels.Doctors;
using MedSino.Domain.Entities.Doctors;

namespace MedSino.DataAccess.Interfaces.Doctors;

public interface IDoctorRepository : IRepository<Doctor, Doctor>,
    IGetAll<Doctor>, ISearchable<Doctor>
{
    public Task<IList<DoctorsViewModel>?> GetByCategoryIdAsync(long categoryId);
    public Task<IList<DoctorsViewModel>?> SearchAsync(string search);
    public Task<Doctor?> GetByPhoneAsync(string phone);
}
