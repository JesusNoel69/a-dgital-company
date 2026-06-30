using MediatR;

namespace ADigitalCompany.Application.Features.Employees.Commands.AssignManager
{
    public class AssignManagerCommand : IRequest<Unit>
    {
        public string DeartmentCode { get; set; }
        public string ManagerId { get; set;}
    }
}