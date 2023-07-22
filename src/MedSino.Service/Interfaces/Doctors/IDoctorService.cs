using MedSino.DataAccess.ViewModels.Doctors;

namespace MedSino.Service.Interfaces.Doctors;

public interface IDoctorService
{
    public Task<DoctorsViewModel?> GetByCategoryIdAsync(long categoryId);
}
