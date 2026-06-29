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
        public Department Department { get; private set; }
        public decimal Salary { get; private set; }
    }
}