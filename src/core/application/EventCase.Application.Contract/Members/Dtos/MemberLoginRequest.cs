namespace EventCase.Application.Contract.Employees.Dtos
{
    public class MemberLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
