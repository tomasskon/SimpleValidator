using Microsoft.EntityFrameworkCore;

namespace LibraryImplementation.Repository.Tests
{
    public class RepositoryTestBase
    {
        protected readonly LibraryImplementationDbContext DbContext;

        public RepositoryTestBase()
        {
            var builder = new DbContextOptionsBuilder<LibraryImplementationDbContext>();
            builder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=LibraryImplementationTests;Integrated Security=True");
            builder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            DbContext = new LibraryImplementationDbContext(builder.Options);
        }
    }
}