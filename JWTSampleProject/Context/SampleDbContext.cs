using JWTSampleProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;

namespace JWTSampleProject.Context
{
    public class SampleDbContext : DbContext , ISampleDbContext, IDisposable
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public SampleDbContext(DbContextOptions<SampleDbContext> options, IConfiguration configuration) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                base.Dispose();
            }
        }
    }
}
