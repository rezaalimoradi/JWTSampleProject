using JWTSampleProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;

namespace JWTSampleProject.Context
{
    public class AppDbContext : DbContext , IAppDbContext
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
