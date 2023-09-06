namespace Generic.Database
{
    using Generic.Database.Configuration;
    using Generic.Database.Entities;
    using Generic.Database.SeedDatabase;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection.Emit;

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        #region Entities

        public DbSet<Tenant> Tenants { get; set; }

        #endregion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        #region Overrides

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigureDbModel();
            builder.Seed();
            base.OnModelCreating(builder);
        }

        #endregion
    }
}