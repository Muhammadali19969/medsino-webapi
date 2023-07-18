using MedSino.DataAccess.Interfaces.Categories;
using MedSino.DataAccess.Utils;
using MedSino.Domain.Entities.Categories;
using MedSino.Domain.Exceptions.Categories;
using MedSino.Service.Dtos;
using MedSino.Service.Interfaces;

namespace MedSino.Service.Services.Categories;

public class CategoryService : ICategoryService
{
    private ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        this._repository = repository;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();
    

    public Task<bool> CreateAsync(CategoryCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Category>> GetAllAsync(PaginationParams @params)
    {
        var category = _repository.GetAllAsync(@params);
        return category;
    }

    public async Task<Category> GetByIdAsync(long categoryId)
    {
        var category = await _repository.GetByIdAsync(categoryId);
        if (category is null) throw new CategoryNotFoundException();
        return category;
    }

    public Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
