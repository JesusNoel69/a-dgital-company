using ADigitalCompany.Application.Models.Employee;
using ADigitalCompany.Domain;
using AutoMapper;

namespace ADigitalCompany.Application.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();
        }
    }
}