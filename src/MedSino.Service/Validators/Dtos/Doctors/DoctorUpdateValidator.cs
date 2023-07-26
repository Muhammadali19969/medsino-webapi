using FluentValidation;
using MedSino.Service.Common.Helpers;
using MedSino.Service.Dtos.Doctors;

namespace MedSino.Service.Validators.Dtos.Doctors;

public class DoctorUpdateValidator : AbstractValidator<DoctorUpdateDto>
{
    public DoctorUpdateValidator()
    {
        RuleFor(dto => dto.FirstName).NotNull().NotEmpty().WithMessage("Name field is required!")
            .MinimumLength(3).WithMessage("FirstName must be more than 3 characters")
            .MaximumLength(50).WithMessage("FirstName must be less than 50 characters");

        RuleFor(dto => dto.LastName).NotNull().NotEmpty().WithMessage("Name field is required!")
            .MinimumLength(3).WithMessage("LastName must be more than 3 characters")
            .MaximumLength(50).WithMessage("LastName must be less than 50 characters");

        RuleFor(dto => dto.PhoneNumber).NotNull().NotEmpty().WithMessage("Phone number field is required!")
            .Must(phone => PhoneNumberValidator.IsValid(phone)).WithMessage("Phone number is incorrect!");

        When(dto => dto.Image is not null, () =>
        {
            int maxImageSizeMB = 5;
            RuleFor(dto => dto.Image!.Length).LessThan(maxImageSizeMB * 1024 * 1024).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
            RuleFor(dto => dto.Image!.FileName).Must(predicate =>
            {
                FileInfo fileInfo = new FileInfo(predicate);
                return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);
            }).WithMessage("This file type is not image file");
        });
    }
}
