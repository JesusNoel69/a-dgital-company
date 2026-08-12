using ADigitalCompany.Application.Interfaces.Identity;
using ADigitalCompany.Application.Interfaces.Persistence;
using ADigitalCompany.Application.Models.Employee;
using AutoMapper;
using MediatR;

namespace ADigitalCompany.Application.Features.Employees.Queries.GetEmployeesByField
{
    public class GetEmployeesByFieldQueryHandler(IMapper _mapper, IEmployeeRepository _repository, IUserService _userService) : IRequestHandler<GetEmployeesByFieldQuery, IReadOnlyList<EmployeeDto>>
    {
        public async Task<IReadOnlyList<EmployeeDto>> Handle(
            GetEmployeesByFieldQuery request,
            CancellationToken cancellationToken)
        {
            var employeesTask =
                _repository.GetByFieldAsync(request.Field);

            var userIdsTask =
                _userService.GetUserIdsByField(request.Field);

            await Task.WhenAll(employeesTask, userIdsTask);

            var employeesByFields = await employeesTask;
            var userIds = await userIdsTask;

            var employeesByUserIds =
                await _repository.GetByIdentityUserIdsAsync(userIds);

            var employees = employeesByFields
                .Concat(employeesByUserIds)
                .DistinctBy(x => x.Id)
                .ToList();

            return _mapper.Map<IReadOnlyList<EmployeeDto>>(employees);
        }
    }
}