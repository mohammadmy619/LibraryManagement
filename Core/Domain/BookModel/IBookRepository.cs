using Domain.AuthorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BookModel
{
    public interface IBookRepository
    {
        public Task<IReadOnlyCollection<Book>> GetBooksAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

        public Task<Book?> GetBookByIdAsync(Guid BookId, CancellationToken cancellationToken);

        public Task<Guid> AddBookAsync(Book book, CancellationToken cancellationToken);
        public void UpdateBookAsync(Book book);


        Task SaveChangesAsync(CancellationToken cancellationToken);






    }
}
