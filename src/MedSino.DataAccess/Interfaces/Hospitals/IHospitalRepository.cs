
using MedSino.DataAccess.Common.Interfaces;
using MedSino.DataAccess.Repositories;
using MedSino.Domain.Entities.Categories;
using MedSino.Domain.Entities.Hospitals;

namespace MedSino.DataAccess.Interfaces.Hospitals;

public interface IHospitalRepository : IRepository<Hospital,Hospital>,
    IGetAll<Hospital>
{

}
