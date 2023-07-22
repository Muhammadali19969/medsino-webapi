using MedSino.DataAccess.Interfaces.Doctors;
using MedSino.DataAccess.ViewModels.Doctors;
using MedSino.Service.Interfaces.Doctors;

namespace MedSino.Service.Services.Doctors;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;

    public DoctorService(IDoctorRepository doctorRepository)
    {
        this._doctorRepository = doctorRepository;
    }

    public async Task<DoctorsViewModel?> GetByCategoryIdAsync(long categoryId)
    {
        var data = await _doctorRepository.GetByCategoryIdAsync(categoryId);
        return data;
    }
}
