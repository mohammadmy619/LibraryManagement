using Domain.AuthorModel;
using System.Threading;

namespace Infrastructure.Repositories.Books
{
    public class BookRepository(LibraryDbContext _dbContext) : IBookRepository
    {
        public async Task<Guid> AddBookAsync(Book book, CancellationToken cancellationToke)
        {
            // Add the author to the database asynchronously  
            var result = await _dbContext.Book.AddAsync(book, cancellationToke);

            // Return the Id of the newly created author  
            return result.Entity.Id;
           
        }

        public async Task<IReadOnlyCollection<Book>> GetBooksAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await _dbContext.Book.AsNoTracking().ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(Guid BookId, CancellationToken cancellationToke)
        {
            return await _dbContext.Book.AsNoTracking().FirstOrDefaultAsync(b => b.Id == BookId);
        }
        public void UpdateBookAsync(Book book)
        {
             _dbContext.Book.Update(book);
        }
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
           await _dbContext.SaveChangesAsync(cancellationToken);
        }


    }
}
