
using MedSino.DataAccess.Common.Interfaces;
using MedSino.Domain.Entities.Hospitals;

namespace MedSino.DataAccess.Interfaces.Hospitals;

public interface IHospitalRepository : IRepository<Hospital, Hospital>,
    IGetAll<Hospital>
{

}
