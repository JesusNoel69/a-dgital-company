using ADigitalCompany.Domain.Common;

namespace ADigitalCompany.Domain
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Desciption { get; set; }
        public string? Location { get; set; }
        public Guid? ResponsibleId { get; set; }
    }
}