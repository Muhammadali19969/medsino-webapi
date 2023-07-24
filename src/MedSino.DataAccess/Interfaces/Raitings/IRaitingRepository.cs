using MedSino.Domain.Entities.Raitings;

namespace MedSino.DataAccess.Interfaces.Raitings;

public interface IRaitingRepository
{
    public Task<long> CreateAsync(Raiting raiting);
    
}
