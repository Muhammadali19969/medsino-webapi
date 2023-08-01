using FluentValidation;
using MedSino.Service.Dtos.Doctors;

namespace MedSino.Service.Validators.Dtos.Doctors;

public class DoctorCreateValidator : AbstractValidator<DoctorCreateDto>
{
    public DoctorCreateValidator()
    {
        RuleFor(dto => dto.FirstName).NotNull().NotEmpty().WithMessage("Name field is required!")
            .MinimumLength(3).WithMessage("FirstName must be more than 3 characters")
            .MaximumLength(50).WithMessage("FirstName must be less than 50 characters");

        RuleFor(dto => dto.LastName).NotNull().NotEmpty().WithMessage("Name field is required!")
            .MinimumLength(3).WithMessage("LastName must be more than 3 characters")
            .MaximumLength(50).WithMessage("LastName must be less than 50 characters");

        RuleFor(dto => dto.PhoneNumber).Must(phone => PhoneNumberValidator.IsValid(phone))
            .WithMessage("Phone number is invalid! ex: +998xxYYYAABB");

        RuleFor(dto => dto.Password).Must(password => PasswordValidator.IsStrongPassword(password).IsValid)
            .WithMessage("Password is not strong password!");

        RuleFor(dto => dto.StartWorkTime).NotNull().NotEmpty().WithMessage("StartWorkTime field is required!");
        RuleFor(dto => dto.EndWorkTime).NotNull().NotEmpty().WithMessage("EndWorkTime field is required!");
        RuleFor(dto => dto.LunchTime).NotNull().NotEmpty().WithMessage("LunchTime field is required!");

        //int maxImageSizeMB = 10;
        //RuleFor(dto => dto.Image.Length).LessThan(maxImageSizeMB * 1024 * 1024 + 1).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
        //RuleFor(dto => dto.Image.FileName).Must(predicate =>
        //{
        //    FileInfo fileInfo = new FileInfo(predicate);
        //    return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);
        //}).WithMessage("This file type is not image file");
    }
}
