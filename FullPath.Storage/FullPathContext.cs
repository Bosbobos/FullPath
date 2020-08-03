using FullPath.Storage.Entity;
using Microsoft.EntityFrameworkCore;

namespace FullPath.Storage
{
    public class FullPathContext
    {
        public class ExampleFullPathContext : DbContext
        {
            public ExampleFullPathContext(DbContextOptions<ExampleFullPathContext> options)
                : base(options)
            {
            }

            public DbSet<Book> Books { get; set; }
        }
    }
}
