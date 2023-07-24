using MedSino.DataAccess.Interfaces.Raitings;
using MedSino.Domain.Entities.Raitings;
using MedSino.Service.Common.Helpers;
using MedSino.Service.Dtos.Ratings;
using MedSino.Service.Interfaces.Raitings;

namespace MedSino.Service.Services.Raitings;

public class RaitingService : IRaitingService
{
    private readonly IRaitingRepository _raitingRepository;

    public RaitingService(IRaitingRepository raiting)
    {
        this._raitingRepository = raiting;
    }

    public async Task<bool> CreateAsync(RaitingDto dto)
    {
        var raiting = new Raiting();
        raiting.DoctorId = dto.DoctorId;
        raiting.UserId = dto.UserId;
        raiting.StarCount = dto.StarCount;
        raiting.CreatedAt = raiting.UpdatedAt = TimeHelper.GetDateTime();
        var result = await _raitingRepository.CreateAsync(raiting);
        return result > 0;
    }
}
