using ADigitalCompany.Application.Interfaces.Persistence;
using MediatR;

namespace ADigitalCompany.Application.Features.Employees.Queries.GetEmployeesNumber
{
    public class GetEmployeesNumberQueryHandler(IEmployeeRepository employeeRepository) : IRequestHandler<GetEmployeesNumberQuery, int>
    {
        private readonly IEmployeeRepository _employeeRepository=employeeRepository;
        public async Task<int> Handle(GetEmployeesNumberQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetAsync();
            return employees.Count;
        }
    }
}