using JWTSampleProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;

namespace JWTSampleProject
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
