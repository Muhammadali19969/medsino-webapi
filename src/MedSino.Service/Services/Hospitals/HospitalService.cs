using MedSino.DataAccess.Interfaces.Hospitals;
using MedSino.DataAccess.Utils;
using MedSino.Domain.Entities.Categories;
using MedSino.Domain.Entities.Hospitals;
using MedSino.Domain.Exceptions.Categories;
using MedSino.Domain.Exceptions.Files;
using MedSino.Domain.Exceptions.Hospitals;
using MedSino.Service.Common.Helpers;
using MedSino.Service.Dtos.Hospitals;
using MedSino.Service.Interfaces.Common;
using MedSino.Service.Interfaces.Hospitals;
using System.ComponentModel.Design;

namespace MedSino.Service.Services.Hospitals;

public class HospitalService : IHospitalService
{
    private readonly IHospitalRepository _repository;
    private readonly IFileService _fileService;

    public HospitalService(IHospitalRepository repository,IFileService fileservice)
    {
        this._repository = repository;
        this._fileService = fileservice;
    }
    public async Task<long> CountAsync()
    {
        return await _repository.CountAsync();
    }
    

    public async Task<bool> CreateAsync(HospitalCreateDto dto)
    {
        string imagepath = await _fileService.UploadImageAsync(dto.Image);
        Hospital hospital = new Hospital();
        hospital.Name = dto.Name;
        hospital.ImagePath = imagepath;
        hospital.Description = dto.Description;
        hospital.PhoneNum1 = dto.PhoneNumber1;
        hospital.PhoneNum2 = dto.PhoneNumber2;
        hospital.Address = dto.Address;
        hospital.Region = dto.Region;
        hospital.District = dto.District;
        hospital.CreatedAt = hospital.UpdatedAt = TimeHelper.GetDateTime();
        var dbResult = await _repository.CreateAsync(hospital);
        return dbResult > 0;
    }

    public async Task<bool> DeleteAsync(long hospitalId)
    {
        var hospital = await _repository.GetByIdAsync(hospitalId);
        if (hospital is null) throw new HospitalNotFoundException();

        var result = await _fileService.DeleteImageAsync(hospital.ImagePath);
        if (result == false) throw new ImageNotFoundException();

        var dbResult = await _repository.DeleteAsync(hospitalId);
        return dbResult > 0;
    }

    public Task<IList<Hospital>> GetAllAsync(PaginationParams @params)
    {
        return _repository.GetAllAsync(@params);
    }

    public async Task<Hospital> GetByIdAsync(long hospitalId)
    {
        var hospital = await _repository.GetByIdAsync(hospitalId);
        if (hospital is null) throw new HospitalNotFoundException();
        return hospital;
    }

    public async Task<bool> UpdateAsync(long hospitalId, HospitalUpdateDto dto)
    {
        var hospital = await _repository.GetByIdAsync(hospitalId);
        if (hospital is null) throw new HospitalNotFoundException();

        hospital.Name = dto.Name;
        hospital.Description = dto.Description;
        hospital.PhoneNum1 = dto.PhoneNumber1;
        hospital.PhoneNum2 = dto.PhoneNumber2;
        hospital.Address = dto.Address;
        hospital.Region= dto.Region;
        hospital.District = dto.District;


        if (dto.Image is not null)
        {
            await _fileService.DeleteImageAsync(hospital.ImagePath);
            hospital.ImagePath = await _fileService.UploadImageAsync(dto.Image);
        }

        hospital.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(hospitalId, hospital);
        return dbResult > 0;
    }
}
