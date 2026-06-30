namespace ADigitalCompany.Application.Models.Employee
{
    public class EmployeeDto
    {
        public string Name { get; set;}
        public string LastName { get; set;}
        public string Rfc {get; set;}
        public string SocialNumber {get; set;}
        public string ClockNumber {get; set;}
        public DateTime HireDate { get; set;}
        public string Email {get; set;}
        public string? PhotoUrl {get; set;}
    }
}