using MedSino.DataAccess.Common.Interfaces;
using MedSino.Domain.Entities.Categories;

namespace MedSino.DataAccess.Interfaces.Categories;

public interface ICategoryRepository : IRepository<Category, Category>,
    IGetAll<Category>
{
}
