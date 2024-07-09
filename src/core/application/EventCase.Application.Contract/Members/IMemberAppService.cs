using EventCase.Application.Contract.Employees.Dtos;
using EventCase.Application.Contract.Members.Dtos;
using EventCase.Application.Contract.ServiceTypes;


namespace EventCase.Application.Contract.Employees
{
    public interface IMemberAppService
    {
        Task<ServiceResponse<MemberDto>> Create(MemberRegisterDto member);
        Task<ServiceResponse<MemberDto>> Update(MemberDto member);

    }
}
