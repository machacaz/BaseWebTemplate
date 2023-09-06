namespace Generic.Database.Helpers
{
    using Microsoft.EntityFrameworkCore;

    internal static class SeedDataHelper
    {
        internal static void SeedData<T>(this ModelBuilder modelBuilder, List<T> seedData) where T : class
        {
            modelBuilder.Entity<T>().HasData(seedData);
        }
    }
}