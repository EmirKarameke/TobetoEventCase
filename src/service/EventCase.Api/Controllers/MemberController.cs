using AutoMapper;
using EventCase.Application.Contract.Employees.Dtos;
using EventCase.Application.Contract.Members.Dtos;
using EventCase.Application.Contract.ServiceTypes;
using EventCase.Auth;
using EventCase.Domain.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventCase.Api.Controllers;

[ApiController]
[Route("[controller]/[action]/")]
public class MemberController : Controller
{
    IAuthService<Guid> authService;
    IMapper mapper;

    public MemberController(IAuthService<Guid> authService, IMapper mapper)
    {
        this.authService = authService;
        this.mapper = mapper;
    }

    //[Authorize(EventCasePermissions.Employee.Create)]
    //[Authorize(Roles = $"{EventCasePermissions.Employee.Create}")]
    //[Authorize(Policy = "EmployeeOrMember")]
    [HttpPost]
    public async Task<ServiceResponse<string>> Register(MemberRegisterDto member)
    {
        try
        {
            Member member1 = new Member()
            {
                EmailOrUserName = member.EmailOrUserName,
                FullName = member.FullName,
                UserName = member.UserName
            };
            var result = await authService.Register(member1, member.Password);
            var response = new ServiceResponse<string>()
            {
                Success = result,
                Message = result ? "BAŞARILI" : "HATA OLUŞTU"
            };

            return response;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    [HttpPost]
    public async Task<ServiceResponse<string>> Login(MemberLoginRequest user)
    {
        var response = new ServiceResponse<string>();
        var result = await authService.Login(user.Email, user.Password);
        if (!string.IsNullOrEmpty(result))
        {
            response.Data = result;
        }
        return response;
    }

    [Authorize]
    [HttpGet]
    public async Task<string> TestAuth()
    {
        return "Başarılı";
    }
}
