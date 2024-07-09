using AutoMapper;
using EventCase.Application.Contract.Employees.Dtos;
using EventCase.Application.Contract.Members.Dtos;
using EventCase.Domain.Employees;

namespace EventCase.Application.Employees.MapProfiles
{
    public class MemberMapProfile : Profile
    {
        public MemberMapProfile()
        {
            CreateMap<MemberDto, Member>().ReverseMap();
            CreateMap<MemberRegisterDto, Member>().ReverseMap();

        }
    }
}
