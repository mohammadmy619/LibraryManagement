using Domain.AuthorModel;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Authors
{
    public class AuthorRepository(LibraryDbContext _dbContext): IAuthorRepository
    {
        public async Task<Guid> AddAuthorAsync(Author author, CancellationToken cancellationToken)
        {
            // Add the author to the database asynchronously  
            var result = await _dbContext.Author.AddAsync(author, cancellationToken);

            // Return the Id of the newly created author  
            return result.Entity.Id;
        }

        public async Task<IReadOnlyCollection<Book?>> GetAuthorBooksByAuthorId(Guid authorId, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await _dbContext.Book.Where(b=>b.AuthorId == authorId)
                .AsNoTracking()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .OrderByDescending(x => x.Id)
                .ToListAsync(cancellationToken);
        }

        public async Task<Author?> GetAuthorByIdAsync(Guid authorId, CancellationToken cancellationToken)
        {
            return await _dbContext.Author
            .FirstOrDefaultAsync(author => author.Id == authorId, cancellationToken);
        }

        public async Task<IReadOnlyCollection<Author>> GetAuthorsAsync(int pageNumber, int pageSize,  CancellationToken cancellationToken)
        {
           return await _dbContext.Author.AsNoTracking()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .OrderByDescending(x => x.Id)
                .ToListAsync(cancellationToken);
        }

      

        public void UpdateAuthorAsync(Author author)
        {
             _dbContext.Author.Update(author);
        }
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
