using AutoMapper;
using ADigitalCompany.Application.Features.WorkItems.Commands.CreateWorkItem;
using ADigitalCompany.Application.Features.WorkItems.Commands.UpdateWorkItem;
using ADigitalCompany.Application.Models.WorkItem;
using ADigitalCompany.Domain;

namespace ADigitalCompany.Application.MappingProfiles
{
    public class WorkItemProfile : Profile
    {
        public WorkItemProfile()
        {
            CreateMap<CreateWorkItemCommand, WorkItem>();
            CreateMap<UpdateWorkItemCommand, WorkItem>();
            CreateMap<WorkItem, WorkItemDto>().ReverseMap();
        }
    }
}