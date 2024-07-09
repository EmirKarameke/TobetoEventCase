namespace BookSwap.Application.Contract.Employees.Dtos
{
    public class EmployeeLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
