using MedSino.DataAccess.Common.Interfaces;
using MedSino.DataAccess.ViewModels.Doctors;
using MedSino.Domain.Entities.Doctors;

namespace MedSino.DataAccess.Interfaces.Doctors;

public interface IDoctorRepository : IRepository<Doctor,Doctor>,
    IGetAll<Doctor>
{ 
    public Task<long> CreateAsync1(Doctor doctor);
    public Task<IList<DoctorsViewModel>?> GetByCategoryIdAsync(long categoryId);
}
