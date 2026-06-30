namespace ADigitalCompany.Application.Models.Department
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string? Description { get; set; }
        public string? Location { get; set; }
        public UserSummaryDto? Manager { get; set; }
    }
}