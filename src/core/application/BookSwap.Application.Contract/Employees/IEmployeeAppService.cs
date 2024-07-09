using BookSwap.Application.Contract.Employees.Dtos;
using BookSwap.Application.Contract.ServiceTypes;


namespace BookSwap.Application.Contract.Employees
{
    public interface IEmployeeAppService
    {
        Task<ServiceResponse<EmployeeDto>> Create(EmployeeDto employee);
        Task<ServiceResponse<EmployeeDto>> Update(EmployeeDto employee);

    }
}
