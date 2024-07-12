using Employee.Permissions.Domain.Entities;
using Employee.Permissions.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employee.Permissions.Infrastructure.Persistence.Configuration
{
    public class PermissionsConfiguration : IEntityTypeConfiguration<PermissionEntity>
    {
        public void Configure(EntityTypeBuilder<PermissionEntity> builder)
        {
            builder.ToTable("Permissions");

            builder.HasKey(c => c.IdPermission).HasName("IdPermission");
            builder.Property(c => c.IdPermission).HasMaxLength(100);
            builder.Property(c => c.IdPermission).HasConversion(
            permissionId => permissionId.Value,
            value => Id.Create(value));

            builder.Property(c => c.IdEmployee).HasConversion(employeeId => employeeId.Value, value => Id.Create(value)).HasColumnName("IdEmployee").HasMaxLength(100);
            builder.Property(c => c.IdPermissionType).HasConversion(permissionTypeId => permissionTypeId.Value,value => Id.Create(value)).HasColumnName("IdPermissionType").HasMaxLength(100);

            builder.Property(c => c.User).HasMaxLength(10);
            builder.Property(c => c.CreationDate).HasColumnName("User");
            builder.Property(c => c.CreationDate).HasColumnName("CreationDate");

            builder.Ignore(c => c.Employee);
            builder.Ignore(c => c.PermissionType);
            builder.Ignore(c => c.Active);

        }
    }
}
