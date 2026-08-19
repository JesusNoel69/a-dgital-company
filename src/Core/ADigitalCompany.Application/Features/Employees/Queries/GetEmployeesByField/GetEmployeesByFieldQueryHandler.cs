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

            var usersTask =
                _userService.GetUsersByField(request.Field);

            await Task.WhenAll(employeesTask, usersTask);

            var employeesByField = await employeesTask;
            var usersByField = await usersTask;

                var employees = employeesByField
                .Concat(
                    await _repository.GetByIdentityUserIdsAsync(
                        usersByField.Select(x => x.Id).ToList()
                    )
                )
                .DistinctBy(x => x.Id)
                .ToList();
            var result = employees
                .Select(employee =>
                {
                    var user = usersByField
                        .FirstOrDefault(u => u.Id == employee.IdentityUserId);

                    return new EmployeeDto
                    {
                        Name = user?.FirstName ?? "",
                        LastName = user?.LastName ?? "",
                        Email = user?.Email ?? "",
                        ClockNumber = employee.ClockNumber,
                        PhotoUrl = employee.PhotoUrl,
                        Rfc = employee.Rfc,
                        SocialNumber = employee.SocialNumber,
                        HireDate = employee.HireDate,
                        JobPosition = employee.JobPosition,
                    };
                })
                .ToList();

            return result;
        }
    }
}