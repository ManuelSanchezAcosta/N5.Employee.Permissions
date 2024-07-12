using Employee.Permissions.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Employee.Permissions.Domain.ValueObjects;

namespace Employee.Permissions.Infrastructure.Persistence.Configuration
{
    public class EmployeesConfiguration: IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(c => c.IdEmployee).HasName("IdEmployee");
            builder.Property(c => c.IdEmployee).HasMaxLength(100);
            builder.Property(c => c.IdEmployee).HasConversion(
            employeeId => employeeId.Value,
            value => Id.Create(value));


            builder.Property(c => c.Name).HasColumnName("Name").HasMaxLength(50);
            builder.Property(c => c.Name).HasConversion(
            employeeName => employeeName.Value,
            value => Name.Create(value));

            builder.Property(c => c.LastName).HasColumnName("LastName").HasMaxLength(50);
            builder.Property(c => c.LastName).HasConversion(
            lastName => lastName.Value,
            value => LastName.Create(value));

            builder.Property(c => c.Email).HasColumnName("Email").HasMaxLength(255);
            builder.HasIndex(c => c.Email).IsUnique();
            builder.Property(c => c.Email).HasConversion(
            email => email.Value,
            value => Email.Create(value));
            
            builder.Property(c => c.Active).HasColumnName("Active");

            builder.Property(c => c.User).HasMaxLength(10);
            builder.Property(c => c.CreationDate).HasColumnName("User");
            builder.Property(c => c.CreationDate).HasColumnName("CreationDate");

            builder.Ignore(c => c.Permissions);            
                        
        }

    }
}
