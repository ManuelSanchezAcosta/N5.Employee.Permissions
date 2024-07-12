using Employee.Permissions.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Employee.Permissions.Domain.ValueObjects;

namespace Employee.Permissions.Infrastructure.Persistence.Configuration
{
    public class PermissionTypesConfiguration : IEntityTypeConfiguration<PermissionTypeEntity>
    {
        public void Configure(EntityTypeBuilder<PermissionTypeEntity> builder)
        {
            builder.ToTable("PermissionTypes");
            builder.HasKey(c => c.IdPermissionType).HasName("IdPermissionType");
            builder.Property(c => c.IdPermissionType).HasMaxLength(100);
            builder.Property(c => c.IdPermissionType).HasConversion(
            permissionTypeId => permissionTypeId.Value,
            value => Id.Create(value));

            builder.Property(c => c.Description).HasMaxLength(50);
            builder.HasIndex(c => c.Description).IsUnique();
            builder.Property(c => c.Description).HasConversion(
            description => description.Value,
            value => Description.Create(value));

            builder.Property(c => c.Active);

            builder.Property(c => c.User).HasMaxLength(10);
            builder.Property(c => c.CreationDate).HasColumnName("User");
            builder.Property(c => c.CreationDate).HasColumnName("CreationDate");

            builder.Ignore(c => c.Permissions);
        }
    }
}
