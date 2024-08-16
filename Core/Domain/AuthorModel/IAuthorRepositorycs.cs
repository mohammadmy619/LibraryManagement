

using Domain.BookModel;

namespace Domain.AuthorModel
{
    public interface IAuthorRepository
    {

        public Task<IReadOnlyCollection<Author>> GetAuthorsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

        public Task<Author?> GetAuthorByIdAsync(Guid authorId, CancellationToken cancellationToken);

        public Task<IReadOnlyCollection<Book?>> GetAuthorBooksByAuthorId(Guid authorId, int pageNumber, int pageSize, CancellationToken cancellationToken);
        
        public Task<Guid> AddAuthorAsync(Author author, CancellationToken cancellationToken);
        public void UpdateAuthorAsync(Author author);

        Task SaveChangesAsync(CancellationToken cancellationToken);


    }
}
