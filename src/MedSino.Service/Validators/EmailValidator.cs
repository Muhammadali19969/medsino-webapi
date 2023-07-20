using FluentValidation;
using MedSino.Service.Dtos.Auth;
using System.Text.RegularExpressions;

namespace MedSino.Service.Validators;

public class EmailValidator : AbstractValidator<RegisterDto>
{
    public static bool IsValidEmail(string email)
    {
        const string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                         + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                                         + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

        bool result = new Regex(validEmailPattern, RegexOptions.IgnoreCase).IsMatch(email);
        return result;
    }

}
