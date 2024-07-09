using AutoMapper;
using BookSwap.Application.Contract.Employees.Dtos;
using BookSwap.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSwap.Application.Employees.MapProfiles
{
    public class EmployeeMapProfile : Profile
    {
        public EmployeeMapProfile()
        {
            CreateMap<EmployeeDto,Employee>().ReverseMap();
        }
    }
}
