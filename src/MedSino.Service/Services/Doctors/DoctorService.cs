using MedSino.DataAccess.Interfaces;
using MedSino.DataAccess.Interfaces.Doctors;
using MedSino.DataAccess.Interfaces.Raitings;
using MedSino.DataAccess.ViewModels.Doctors;
using MedSino.Domain.Entities.Categories;
using MedSino.Domain.Entities.Doctors;
using MedSino.Domain.Entities.Raitings;
using MedSino.Domain.Exceptions.Categories;
using MedSino.Domain.Exceptions.Doctors;
using MedSino.Domain.Exceptions.Files;
using MedSino.Service.Common.Helpers;
using MedSino.Service.Common.Security;
using MedSino.Service.Dtos.Doctors;
using MedSino.Service.Interfaces.Common;
using MedSino.Service.Interfaces.Doctors;

namespace MedSino.Service.Services.Doctors;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IRaitingRepository _raitingRepository;
    private readonly IFileService _fileService;

    public DoctorService(IDoctorRepository doctorRepository,
        IFileService fileService,
        IRaitingRepository raitingRepository)
    {
        this._fileService= fileService;
        this._doctorRepository = doctorRepository;
        this._raitingRepository = raitingRepository;
    }

    public async Task<bool> CreateAsync(DoctorCreateDto dto)
    {
        var doctor = new Doctor();
        doctor.CategoryId = dto.CategoryId;
        doctor.FirstName = dto.FirstName;
        doctor.LastName = dto.LastName;
        doctor.Email = dto.Email;
        doctor.PhoneNumber = dto.PhoneNumber;
        
        if(dto.Image is not null)
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

        var result = await _doctorRepository.CreateAsync(doctor);
        if (result > 0)
        {
            var raiting = new Raiting();
            raiting.StarCount = 0;
            raiting.DoctorId = result;
            raiting.UserId = 0;
            raiting.CreatedAt = raiting.UpdatedAt = TimeHelper.GetDateTime();
            var res = await _raitingRepository.CreateAsync(raiting);
            return true;
        }
        return false;
        
    }

    public async Task<IList<DoctorsViewModel>?> GetByCategoryIdAsync(long categoryId)
    {
        var data = await _doctorRepository.GetByCategoryIdAsync(categoryId);
        if (data == null) throw new DoctorNotFoundException();
        return data;
    }

    public async Task<bool> UpdateAsync(long doctorId, DoctorUpdateDto dto)
    {
        var doctor = await _doctorRepository.GetByIdAsync(doctorId);
        if (doctor is null) throw new CategoryNotFoundException();

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
