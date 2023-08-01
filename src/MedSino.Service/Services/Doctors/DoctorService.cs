using MedSino.DataAccess.Interfaces.Doctors;
using MedSino.DataAccess.Interfaces.Raitings;
using MedSino.DataAccess.Utils;
using MedSino.DataAccess.ViewModels.Doctors;
using MedSino.Domain.Entities.Doctors;
using MedSino.Domain.Entities.Users;
using MedSino.Domain.Exceptions.Auth;
using MedSino.Domain.Exceptions.Categories;
using MedSino.Domain.Exceptions.Doctors;
using MedSino.Domain.Exceptions.Users;
using MedSino.Service.Common.Helpers;
using MedSino.Service.Common.Security;
using MedSino.Service.Dtos.Doctors;
using MedSino.Service.Interfaces.Auth;
using MedSino.Service.Interfaces.Common;
using MedSino.Service.Interfaces.Doctors;

namespace MedSino.Service.Services.Doctors;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IRaitingRepository _raitingRepository;
    private readonly ITokenService _tokenService;
    private readonly IPaginator _paginator;
    private readonly IIdentityService _identity;
    private readonly IFileService _fileService;

    public DoctorService(IDoctorRepository doctorRepository,
        IFileService fileService,
        IRaitingRepository raitingRepository,
        ITokenService tokenService,
        IPaginator paginator,
        IIdentityService identityService)
    {
        this._fileService = fileService;
        this._doctorRepository = doctorRepository;
        this._raitingRepository = raitingRepository;
        this._tokenService = tokenService;
        this._paginator = paginator;
        this._identity = identityService;
    }

    public async Task<bool> CreateAsync(DoctorCreateDto dto)
    {
        var doctor = new Doctor();
        doctor.CategoryId = dto.CategoryId;
        doctor.FirstName = dto.FirstName;
        doctor.LastName = dto.LastName;
        doctor.Email = dto.Email;
        doctor.PhoneNumber = dto.PhoneNumber;

        if (dto.Image is not null)
        {
            string newImagePath = await _fileService.UploadImageAsync(dto.Image);
            doctor.ImagePath = newImagePath;
        }
        doctor.IsMale = dto.IsMale;
        doctor.Address = dto.Address;

        var security = PasswordHasher.Hash(dto.Password);

        doctor.PasswordHash = security.Hash;
        doctor.Salt = security.Salt;
        doctor.WorkExperience = dto.WorkExperience;
        doctor.Region = dto.Region;
        doctor.District = dto.District;
        doctor.Fees = dto.Fees;
        doctor.StartWorkTime = dto.StartWorkTime;
        doctor.EndWorkTime = dto.EndWorkTime;
        doctor.LunchTime = dto.LunchTime;
        doctor.IdentityRole = Domain.Enums.IdentityRole.Doctor;
        doctor.CreatedAt = doctor.UpdatedAt = TimeHelper.GetDateTime();

        var result = await _doctorRepository.CreateAsync(doctor);
        return result > 0;

    }

    public async Task<bool> DeleteAsync(long doctorId)
    {
        //if (doctorId != _identity.UserId && _identity.IdentityRole != Domain.Enums.IdentityRole.Admin) throw new DoctorNotFoundException();
        var doctor = await _doctorRepository.GetByIdAsync(doctorId);
        if (doctor is null) throw new DoctorNotFoundException();

        var result = await _fileService.DeleteImageAsync(doctor.ImagePath);
        var dbResult = await _doctorRepository.DeleteAsync(doctorId);
        return dbResult > 0;

    }

    public async Task<IList<Doctor>> GetAllAsync(PaginationParams @params)
    {
        var doctors = await _doctorRepository.GetAllAsync(@params);
        var count = await _doctorRepository.CountAsync();
        _paginator.Paginate(count, @params);

        return doctors;
    }

    public async Task<IList<DoctorsViewModel>?> GetByCategoryIdAsync(long categoryId)
    {
        var data = await _doctorRepository.GetByCategoryIdAsync(categoryId);
        if (data == null) throw new DoctorNotFoundException();
        return data;
    }

    public async Task<Doctor> GetByIdAsync(long doctorId)
    {
        var doctor = await _doctorRepository.GetByIdAsync(doctorId);
        if (doctor == null) throw new DoctorNotFoundException();
        return doctor;
    }

    public async Task<(bool Result, string Token)> LoginAsync(DoctorLoginDto loginDto)
    {
        var doctor = await _doctorRepository.GetByPhoneAsync(loginDto.PhoneNumber);
        if (doctor is null) throw new DoctorNotFoundException();

        var hasherResult = PasswordHasher.Verify(loginDto.Password, doctor.PasswordHash, doctor.Salt);
        if (hasherResult == false) throw new PasswordNotMatchException();

        string token = _tokenService.GenerateDoctorToken(doctor);
        return (Result: true, Token: token);
    }

    public async Task<IList<DoctorsViewModel>?> SearchAsync(string search)
    {
        var data = await _doctorRepository.SearchAsync(search);
        return data;
    }

    public async Task<bool> UpdateAsync(long doctorId, DoctorUpdateDto dto)
    {
        //if (doctorId != _identity.UserId && _identity.IdentityRole != Domain.Enums.IdentityRole.Admin) throw new DoctorNotFoundException();
        var doctor = await _doctorRepository.GetByIdAsync(doctorId);
        if (doctor is null) throw new DoctorNotFoundException();

        doctor.FirstName = dto.FirstName;
        doctor.LastName = dto.LastName;
        doctor.Address = dto.Address;
        doctor.PhoneNumber = dto.PhoneNumber;
        doctor.Email = dto.Email;
        doctor.WorkExperience = dto.WorkExperience;
        doctor.Region = dto.Region;
        doctor.District = dto.District;
        doctor.StartWorkTime = dto.StartWorkTime;
        doctor.EndWorkTime = dto.EndWorkTime;
        doctor.LunchTime = dto.LunchTime;
        doctor.IsMale = dto.IsMale;
        doctor.Fees = dto.Fees;


        if (dto.Image is not null)
        {
            var deleteResult = await _fileService.DeleteImageAsync(doctor.ImagePath);
            string newImagePath = await _fileService.UploadImageAsync(dto.Image);
            doctor.ImagePath = newImagePath;
        }

        doctor.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _doctorRepository.UpdateAsync(doctorId, doctor);
        return dbResult > 0;
    }
}
