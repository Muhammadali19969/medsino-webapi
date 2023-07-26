using MedSino.DataAccess.Interfaces.Users;
using MedSino.Domain.Entities.Doctors;
using MedSino.Domain.Exceptions.Categories;
using MedSino.Service.Common.Helpers;
using MedSino.Service.Dtos.Users;
using MedSino.Service.Interfaces.Common;
using MedSino.Service.Interfaces.Users;

namespace MedSino.Service.Services.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IFileService _fileService;

    public UserService(IUserRepository userRepository,
        IFileService fileService)
    {
        this._userRepository = userRepository;
        this._fileService = fileService;
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
