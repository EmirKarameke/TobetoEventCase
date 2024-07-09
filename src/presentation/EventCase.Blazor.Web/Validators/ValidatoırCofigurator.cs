using EventCase.Application.Contract.Employees.Dtos;
using EventCase.Application.Contract.Members.Dtos;
using FluentValidation;

namespace EventCase.Blazor.Web.Validators
{
    public static class ValidatorCofigurator
    {
        public static void ConfigureValidator(this IServiceCollection builder)
        {
            builder.AddScoped<AbstractValidator<MemberRegisterDto>, MemberRegisterValidator>();
            builder.AddScoped<AbstractValidator<MemberLoginRequest>, MemberLoginValidator>();
        }
    }
}
