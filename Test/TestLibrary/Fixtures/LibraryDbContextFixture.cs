using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;


namespace TestLibrary.Fixtures;

public class LibraryDbContextFixture : EfDatabaseBaseFixture<LibraryDbContext>
{
    protected override LibraryDbContext BuildDbContext(DbContextOptions<LibraryDbContext> options)
    {
        return new LibraryDbContext(options);
    }
}