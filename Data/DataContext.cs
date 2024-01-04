using BanchMarkProject.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BanchMarkProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=SCORPIONS;Database=TestDB;user id=Yash;password=test@123;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;TrustServerCertificate=True");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }

}
