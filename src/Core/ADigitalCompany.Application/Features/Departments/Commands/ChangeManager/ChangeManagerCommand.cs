using MediatR;

namespace ADigitalCompany.Application.Features.Departments.Commands.ChangeManager
{
    public class ChangeManagerCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Manager { get; set; }
    }
}