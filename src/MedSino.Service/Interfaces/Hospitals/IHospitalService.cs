using MedSino.DataAccess.Utils;
using MedSino.Domain.Entities.Hospitals;
using MedSino.Service.Dtos.Hospitals;

namespace MedSino.Service.Interfaces.Hospitals;

public interface IHospitalService
{
    public Task<long> CountAsync();
    public Task<bool> CreateAsync(HospitalCreateDto dto);
    public Task<IList<Hospital>> GetAllAsync(PaginationParams @params);
    public Task<Hospital> GetByIdAsync(long hospitalId);
    public Task<bool> UpdateAsync(long hospitalId, HospitalUpdateDto dto);
    public Task<bool> DeleteAsync(long hospitalId);


}
