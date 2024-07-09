using AutoMapper;
using EventCase.Application.Contract.Employees;
using EventCase.Application.Contract.Employees.Dtos;
using EventCase.Application.Contract.Members.Dtos;
using EventCase.Application.Contract.ServiceTypes;
using EventCase.Domain.Employees;

namespace EventCase.Application.Employees;

public class MemberAppService : IMemberAppService
{
    IMemberRepository employeeRepository;
    IMapper mapper;

    public MemberAppService(IMemberRepository employeeRepository, IMapper mapper)
    {
        this.employeeRepository = employeeRepository;
        this.mapper = mapper;
    }

    public async Task<ServiceResponse<MemberDto>> Create(MemberRegisterDto member)
    {
        var result = new ServiceResponse<MemberDto>();

        var createdMember = mapper.Map<Member>(member);
        try
        {
            var entity = await employeeRepository.AddAsync(createdMember);
            result.Success = true;
            result.Data = mapper.Map<MemberDto>(entity);
        }
        catch (Exception e)
        {
            result.Success = false;
            result.Message = e.Message;
        }
        return result;
    }

    public async Task<string> Login(string emailOrUserName, string password)
    {
        var user = await employeeRepository.SingleOrDefaultAsync(i => i.EmailOrUserName == emailOrUserName);
        if (user == null) throw new Exception("Kullanıcı Adı Şifre Hatası");

        //var passwordResult = VerifyPassword(password, user.PasswordSalt, user.PasswordHash);
        //if(!passwordResult) throw new Exception("Kullanıcı Adı Şifre Hatası");

        return "";

    }


    public Task<ServiceResponse<MemberDto>> Update(MemberDto employee)
    {
        throw new NotImplementedException();
    }

}
