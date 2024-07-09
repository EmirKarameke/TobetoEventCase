using EventCase.Application.Contract.Members.Dtos;
using FluentValidation;

namespace EventCase.Blazor.Web.Validators
{
    public class MemberRegisterValidator : AbstractValidator<MemberRegisterDto>
    {
        public MemberRegisterValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş olamaz").MinimumLength(10).WithMessage("Şifre 10 karakterden az olamaz");
            RuleFor(x => x.PasswordConfirm).Equal(i => i.Password).WithMessage("Şifreler Uyuşmuyor.");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Ad Soyad boş olamaz").MinimumLength(7).WithMessage("Ad Soyad 7 karakterden az olamaz");
            RuleFor(x => x.EmailOrUserName).NotEmpty().WithMessage("Eposta boş olamaz").EmailAddress().WithMessage("Eposta adresi uygun formatta değil");
        }
    }
}
