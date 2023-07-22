using MedSino.DataAccess.Common.Interfaces;
using MedSino.DataAccess.ViewModels.Doctors;
using MedSino.Domain.Entities.Doctors;

namespace MedSino.DataAccess.Interfaces.Doctors;

public interface IDoctorRepository : IRepository<Doctor,DoctorsViewModel>,
    IGetAll<Doctor>
{ 
    public Task<DoctorsViewModel?> GetByCategoryIdAsync(long categoryId);
}
