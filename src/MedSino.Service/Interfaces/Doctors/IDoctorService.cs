﻿using MedSino.DataAccess.ViewModels.Doctors;
using MedSino.Service.Dtos.Doctors;

namespace MedSino.Service.Interfaces.Doctors;

public interface IDoctorService
{
    public Task<bool> CreateAsync(DoctorCreateDto dto);
    public Task<IList<DoctorsViewModel>?> GetByCategoryIdAsync(long categoryId);
    public Task<bool> UpdateAsync(long doctorId ,DoctorUpdateDto dto);
}
