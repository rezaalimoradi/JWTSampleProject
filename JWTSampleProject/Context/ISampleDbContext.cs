using JWTSampleProject.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTSampleProject.Context
{
    public interface ISampleDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
