using ADigitalCompany.Domain;
using ADigitalCompany.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ADigitalCompany.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdentityUserId)
                .IsRequired()
                .HasMaxLength(450);

            builder.Property(x => x.ClockNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasIndex(x => x.ClockNumber)
                .IsUnique();

            builder.Property(x => x.Rfc)
                .IsRequired()
                .HasMaxLength(13);

            builder.HasIndex(x => x.Rfc)
                .IsUnique();

            builder.Property(x => x.SocialNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Salary)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.JobPosition)
                .HasConversion<int>();

            builder.HasOne(x => x.Department)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new
                {
                    Id = 1,
                    IdentityUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    ClockNumber = "EMP0001",
                    Rfc = "XAXX010101000",
                    SocialNumber = "12345678901",
                    HireDate = new DateTime(2024, 1, 1),
                    JobPosition = JobPosition.Operator,
                    DepartmentId = 1,
                    Salary = 50000m,
                    PhotoUrl = (string?)null
                },
                new
                {
                    Id = 2,
                    IdentityUserId = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                    ClockNumber = "EMP0002",
                    Rfc = "XEXX010101000",
                    SocialNumber = "98765432101",
                    HireDate = new DateTime(2024, 2, 1),
                    JobPosition = JobPosition.Operator,
                    DepartmentId = 2,
                    Salary = 18000m,
                    PhotoUrl = (string?)null
                }
            );
        }
    }
}