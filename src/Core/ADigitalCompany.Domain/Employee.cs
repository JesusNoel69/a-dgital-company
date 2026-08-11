using ADigitalCompany.Domain.Common;
using ADigitalCompany.Domain.Enums;

namespace ADigitalCompany.Domain
{
    public class Employee : BaseEntity
    {
        public string IdentityUserId { get; private set; } = default!;
        public string ClockNumber { get; private set; } = default!;
        public string? PhotoUrl { get; private set; }
        public string Rfc { get; private set; }
        public string SocialNumber { get; private set; }
        public DateTime HireDate { get; private set; }
        public JobPosition JobPosition { get; private set; }
        public int DepartmentId { get; private set; }
        public Department Department { get; private set; } = default!;
        public decimal Salary { get; private set; }
        private Employee(){ }
        public Employee(
            string identityUserId, 
            string clockNumber, 
            string rfc, 
            string socialNumber, 
            DateTime hireDate, 
            JobPosition jobPosition, 
            int departmentId, decimal salary)
        {
            IdentityUserId = identityUserId;
            ClockNumber = clockNumber;
            Rfc = rfc;
            SocialNumber = socialNumber;
            HireDate = hireDate;
            JobPosition = jobPosition;
            DepartmentId = departmentId;
            Salary = salary;
        }
        public void ChangeDepartment(int departmentId)
        {
            if (departmentId <= 0)
                throw new ArgumentException("Invalid department.", nameof(departmentId));

            DepartmentId = departmentId;
        }
        public void ChangeSalary(decimal salary)
        {
            if (salary < 0)
                throw new InvalidOperationException("Salary cannot be negative.");

            Salary = salary;
        }
        public void ChangeJobPosition(JobPosition position)
        {
            JobPosition = position;
        }
        public void ChangePhoto(string? photoUrl)
        {
            PhotoUrl = photoUrl;
        }

        public void ChangeSocialNumber(string socialNumber)
        {
            SocialNumber = socialNumber;
        }

        public void ChangeRfc(string rfc)
        {
            Rfc = rfc;
        }

        public void ChangeClockNumber(string clockNumber)
        {
            ClockNumber = clockNumber;
        }
    }
}