using MedSino.DataAccess.Utils;
using MedSino.Domain.Entities.Categories;
using MedSino.Service.Dtos.Categories;

namespace MedSino.Service.Interfaces.Categories;

public interface ICategoryService
{
    public Task<long> CountAsync();
    public Task<bool> CreateAsync(CategoryCreateDto dto);

    public Task<bool> DeleteAsync(long categoryId);

    public Task<IList<Category>> GetAllAsync(PaginationParams @params);

    public Task<Category> GetByIdAsync(long categoryId);

    public Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto dto);
}
