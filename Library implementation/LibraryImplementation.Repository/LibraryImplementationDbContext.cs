using LibraryImplementation.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryImplementation.Repository
{
    public class LibraryImplementationDbContext : DbContext
    {
        public LibraryImplementationDbContext(DbContextOptions<LibraryImplementationDbContext> options) 
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        
        public DbSet<UserEntity> Users { get; set; }
    }
}