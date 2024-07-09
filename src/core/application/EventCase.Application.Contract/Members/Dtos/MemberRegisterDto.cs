namespace EventCase.Application.Contract.Members.Dtos;

public class MemberRegisterDto
{
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string EmailOrUserName { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
}
