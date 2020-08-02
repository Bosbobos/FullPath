using FullPath.Storage.Entity;
using Microsoft.EntityFrameworkCore;

namespace FullPath.Storage
{
    class FullPathContext
    {
        public class ExampleFullPathContext : DbContext
        {
            public ExampleFullPathContext(DbContextOptions<ExampleFullPathContext> options)
                : base(options)
            {
            }

            public DbSet<BookContent> BookContents { get; set; }

            public DbSet<Book> Books { get; set; }
        }
    }
}
