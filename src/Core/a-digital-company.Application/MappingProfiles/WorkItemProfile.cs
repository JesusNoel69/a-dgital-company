using AutoMapper;
using a-digital-company.Application.Features.WorkItems.Commands.CreateWorkItem;
using a-digital-company.Application.Features.WorkItems.Commands.UpdateWorkItem;
using a-digital-company.Application.Models.WorkItem;
using a-digital-company.Domain;

namespace a-digital-company.Application.MappingProfiles
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