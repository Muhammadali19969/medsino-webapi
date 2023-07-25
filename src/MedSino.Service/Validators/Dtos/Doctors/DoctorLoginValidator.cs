using FluentValidation;
using MedSino.Service.Dtos.Auth;
using MedSino.Service.Dtos.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedSino.Service.Validators.Dtos.Doctors
{
    
    public class DoctorLoginValidator : AbstractValidator<DoctorLoginDto>
    {
        public  DoctorLoginValidator()
        {
            RuleFor(dto => dto.PhoneNumber).Must(phone => PhoneNumberValidator.IsValid(phone))
                .WithMessage("Phone number is invalid! ex: +998xxYYYAABB");

            RuleFor(dto => dto.Password).Must(password => PasswordValidator.IsStrongPassword(password).IsValid)
                .WithMessage("Password is not strong password!");
        }
    }
}
