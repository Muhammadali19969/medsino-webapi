using MedSino.DataAccess.Interfaces.Categories;
using MedSino.DataAccess.Utils;
using MedSino.Domain.Entities.Categories;
using MedSino.Domain.Exceptions.Categories;
using MedSino.Domain.Exceptions.Files;
using MedSino.Service.Common.Helpers;
using MedSino.Service.Dtos.Categories;
using MedSino.Service.Interfaces.Categories;
using MedSino.Service.Interfaces.Common;

namespace MedSino.Service.Services.Categories;

public class CategoryService : ICategoryService
{
    private ICategoryRepository _repository;
    private IFileService _fileService;

    public CategoryService(ICategoryRepository repository, IFileService fileService)
    {
        this._repository = repository;
        this._fileService = fileService;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();


    public async Task<bool> CreateAsync(CategoryCreateDto dto)
    {
        string imagepath = await _fileService.UploadImageAsync(dto.Image);
        Category category = new Category()
        {
            ImagePath = imagepath,
            Name = dto.Name,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };
        var result = await _repository.CreateAsync(category);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long categoryId)
    {
        var category = await _repository.GetByIdAsync(categoryId);
        if (category is null) throw new CategoryNotFoundException();

        var result = await _fileService.DeleteImageAsync(category.ImagePath);
        if (result == false) throw new ImageNotFoundException();

        var dbResult = await _repository.DeleteAsync(categoryId);
        return dbResult > 0;
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


    public async Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto dto)
    {
        var category = await _repository.GetByIdAsync(categoryId);
        if (category is null) throw new CategoryNotFoundException();

        category.Name = dto.Name;

        if (dto.Image is not null)
        {
            var deleteResult = await _fileService.DeleteImageAsync(category.ImagePath);
            if (deleteResult is false) throw new ImageNotFoundException();

            string newImagePath = await _fileService.UploadImageAsync(dto.Image);

            category.ImagePath = newImagePath;
        }

        category.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(categoryId, category);
        return dbResult > 0;
    }


}
