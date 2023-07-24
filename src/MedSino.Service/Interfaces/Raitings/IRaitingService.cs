using MedSino.Service.Dtos.Ratings;

namespace MedSino.Service.Interfaces.Raitings;

public interface IRaitingService
{
    public Task<bool> CreateAsync(RaitingDto dto);
}
