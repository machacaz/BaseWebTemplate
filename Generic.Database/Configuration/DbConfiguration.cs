using Generic.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Platypus.HelperLibrary;

namespace Generic.Database.Configuration
{
    internal static class DbConfiguration
    {
        internal static void ConfigureDbModel(this ModelBuilder model)
        {
            model.Entity<User>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(p => p.Id).ValueGeneratedOnAdd();
                e.Property(p => p.IsAPIUser).IsRequired().HasDefaultValue(false).HasColumnOrder(99);
                e.Property(p => p.Status).IsRequired().HasDefaultValue(Enums.EntityStatus.IsEnabled).HasColumnOrder(100);

                e.HasOne(e => e.CreateUser).WithMany().OnDelete(DeleteBehavior.Restrict);
                e.HasOne(e => e.Tenant).WithMany().OnDelete(DeleteBehavior.Restrict);
            });

            model.Entity<Tenant>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(p => p.Id).ValueGeneratedOnAdd();
                e.Property(p => p.TenantDescription).IsRequired(false);
                e.Property(p => p.IsMainTenant).IsRequired(true).HasDefaultValue(false);
                e.Property(p => p.TenantName).HasMaxLength(50);
                e.Property(p => p.TenantDescription).HasMaxLength(255);
                e.HasIndex(p => p.TenantName).IsUnique();
            });
        }
    }
}