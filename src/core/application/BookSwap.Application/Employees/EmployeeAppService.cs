using BookSwap.Application.Contract.Employees;
using BookSwap.Application.Contract.Employees.Dtos;
using BookSwap.Application.Contract.ServiceTypes;
using BookSwap.Auth;
using BookSwap.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSwap.Application.Employees
{
    public class EmployeeAppService : IEmployeeAppService
    {
        IEmployeeRepository employeeRepository;
        

        public EmployeeAppService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public Task<ServiceResponse<EmployeeDto>> Create(EmployeeDto employee)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Login(string emailOrUserName, string password)
        {
            var user = await employeeRepository.SingleOrDefaultAsync(i => i.EmailOrUserName == emailOrUserName);
            if (user == null) throw new Exception("Kullanıcı Adı Şifre Hatası");

            //var passwordResult = VerifyPassword(password, user.PasswordSalt, user.PasswordHash);
            //if(!passwordResult) throw new Exception("Kullanıcı Adı Şifre Hatası");

            return "";

        }


        public Task<ServiceResponse<EmployeeDto>> Update(EmployeeDto employee)
        {
            throw new NotImplementedException();
        }

    }
}
