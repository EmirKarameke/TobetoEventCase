using EventCase.Application.Contract.Employees.Dtos;
using FluentValidation;

namespace EventCase.Blazor.Web.Validators
{
    public class MemberLoginValidator :AbstractValidator<MemberLoginRequest>
    {
        public MemberLoginValidator() 
        {
            RuleFor(x=>x.Email).NotEmpty().EmailAddress().WithMessage("Eposta adresi uygun formatta değil");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş olamaz").MinimumLength(10).WithMessage("Şifre 10 karakterden az olamaz");

        }
    }
}
