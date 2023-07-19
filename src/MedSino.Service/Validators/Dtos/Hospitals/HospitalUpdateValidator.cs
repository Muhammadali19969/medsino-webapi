
using FluentValidation;
using MedSino.Service.Common.Helpers;
using MedSino.Service.Dtos.Hospitals;

namespace MedSino.Service.Validators.Dtos.Hospitals;

public class HospitalUpdateValidator : AbstractValidator<HospitalUpdateDto>
{
    public HospitalUpdateValidator()
    {
        RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Name field is required!")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters")
            .MaximumLength(50).WithMessage("Name must be less than 50 characters");

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description field is required!")
            .MinimumLength(10).WithMessage("Description field is required!");

        RuleFor(dto => dto.PhoneNumber1).NotNull().NotEmpty().WithMessage("Phone number field is required!")
            .Must(phone => PhoneNumberValidator.IsValid(phone)).WithMessage("Phone number is incorrect!");

        RuleFor(dto => dto.Address).NotNull().NotEmpty().WithMessage("Address field is required!");

        RuleFor(dto => dto.Region).NotNull().NotEmpty().WithMessage("Region field is required!");

        RuleFor(dto => dto.District).NotNull().NotEmpty().WithMessage("District field is required!");

        int maxImageSizeMB = 3;
        RuleFor(dto => dto.Image!.Length).LessThan(maxImageSizeMB * 1024 * 1024 + 1).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
        RuleFor(dto => dto.Image!.FileName).Must(predicate =>
        {
            FileInfo fileInfo = new FileInfo(predicate);
            return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);
        }).WithMessage("This file type is not image file");
    }
}
