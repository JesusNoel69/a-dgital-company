using AutoMapper;
using a_digital_company.Application.Features.WorkItems.Commands.CreateWorkItem;
using a_digital_company.Application.Features.WorkItems.Commands.UpdateWorkItem;
using a_digital_company.Application.Models.WorkItem;
using a_digital_company.Domain;

namespace a_digital_company.Application.MappingProfiles
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