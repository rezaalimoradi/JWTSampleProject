using JWTSampleProject.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTSampleProject.Context
{
    public interface ISampleDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
