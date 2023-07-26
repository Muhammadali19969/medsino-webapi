using MedSino.DataAccess.Interfaces;
using MedSino.DataAccess.Interfaces.Users;
using MedSino.DataAccess.Utils;
using MedSino.Domain.Entities.Doctors;
using MedSino.Domain.Entities.Users;
using MedSino.Domain.Exceptions.Categories;
using MedSino.Domain.Exceptions.Users;
using MedSino.Service.Common.Helpers;
using MedSino.Service.Dtos.Users;
using MedSino.Service.Interfaces.Common;
using MedSino.Service.Interfaces.Users;
using MedSino.Service.Services.Common;

namespace MedSino.Service.Services.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IFileService _fileService;
    private readonly IPaginator _paginator;

    public UserService(IUserRepository userRepository,
        IFileService fileService,
        IPaginator paginator)
    {
        this._userRepository = userRepository;
        this._fileService = fileService;
        this._paginator = paginator;
    }

    public async Task<IList<User>> GetAllAsync(PaginationParams @params)
    {
        var users = await _userRepository.GetAllAsync(@params);
        var count = await _userRepository.CountAsync();
        _paginator.Paginate(count, @params);
        return users;
    }

    public async Task<User> GetByIdAsync(long userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null) throw new UserNotFoundException();
        return user;
    }

    public async Task<bool> UpdateAsync(long userId, UserUpdateDto dto)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null) throw new CategoryNotFoundException();

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.PhoneNumber = dto.PhoneNumber;
        user.Email = dto.Email;
        user.IsMale = dto.IsMale;


        if (dto.Image is not null)
        {
            var deleteResult = await _fileService.DeleteImageAsync(user.ImagePath);
            string newImagePath = await _fileService.UploadImageAsync(dto.Image);
            user.ImagePath = newImagePath;
        }

        user.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _userRepository.UpdateAsync(userId, user);
        return dbResult > 0;
    }
}
