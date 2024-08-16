using System;

namespace Infrastructure.DbContexts
{
    public class LibraryDbContext: DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }
  
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var infrastructureAssembly = typeof(IAssemblyMarker).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(infrastructureAssembly);
        }
    }
}
