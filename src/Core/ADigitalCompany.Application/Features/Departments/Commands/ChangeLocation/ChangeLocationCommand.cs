using MediatR;

namespace ADigitalCompany.Application.Features.Departments.Commands.ChangeLocation
{
    public class ChangeLocationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Location { get; set; }
    }
}