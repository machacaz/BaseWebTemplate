using Generic.Database.Entities;
using Generic.Database.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Generic.Database.SeedDatabase
{
    internal static class SeedDatabaseHelper
    {
        public static void Seed(this ModelBuilder model)
        {
            model.SeedData(new List<Tenant>()
            {
                 new Tenant(){ Id = 1, Identifier = Guid.NewGuid(),  TenantName = "Default", IsMainTenant = true }
            });

            var idRoleGuid = Guid.NewGuid();
            var idUser = Guid.NewGuid();

            var hasher = new PasswordHasher<IdentityUser>();

            var _ = new User();

            model.Entity<IdentityRole>().HasData(new IdentityRole { Id = idRoleGuid.ToString(), Name = "Administrator", NormalizedName = "ADMINISTRATOR" });
            model.Entity<User>().HasData(new User
            {
                Id = idUser.ToString(),
                UserName = "admin",
                Email = "admin@kamonohashi.com",
                PasswordHash = hasher.HashPassword(_, "Jack$Torrance_2001")
            });
        }
    }
}