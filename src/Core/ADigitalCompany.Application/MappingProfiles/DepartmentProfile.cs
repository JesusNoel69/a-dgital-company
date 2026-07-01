using ADigitalCompany.Application.Models.Department;
using ADigitalCompany.Domain;
using AutoMapper;

namespace ADigitalCompany.Application.MappingProfiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDto>();
        }
    }
}