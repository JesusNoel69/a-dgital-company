using ADigitalCompany.Domain.Common;

namespace ADigitalCompany.Domain
{
    public class Department : BaseEntity
    {
        public string Name { get; private set; } = default!;
        public string Code { get; private set; } = default!;
        public string? Description { get; private set; }
        public string? Location { get; private set; }
        public string? ResponsibleId { get; private set; }
        private Department() { }
        public Department(
            string name,
            string code,
            string? description,
            string? location,
            string? responsibleId)
        {
            Name = name;
            Code = code;
            Description = description;
            Location = location;
            ResponsibleId = responsibleId;
        }
        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Department name is required.");

            Name = name;
        }
        public void ChangeCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) //maybe it needs autogenerate utility
                throw new ArgumentException("Department Code is required.");

            Code = code;
        }
        public void ChangeManager(string managerId)
        {
            ResponsibleId = managerId;
        }
        public void ChangeLocation(string? location)
        {
            Location = location;
        }
        public void ChangeDescription(string? description)
        {
            Description = description;
        }
    }
}