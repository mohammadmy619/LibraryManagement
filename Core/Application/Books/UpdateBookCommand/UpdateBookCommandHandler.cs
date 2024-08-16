using Application.Authors.UpdateAuthorCommand;
using Domain.AuthorModel;
using Domain.BookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.books.UpdateBookCommand
{
    public class UpdateBookCommandHandler(IBookRepository BookRepository) : IRequestHandler<UpdateBookCommand, UpdateBookCommandResponse>
    {
        private readonly IBookRepository _BookRepository = BookRepository;
        public async Task<UpdateBookCommandResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            //var CreateAuthor = await _AuthorRepository.AddBookAsync((Book)request, cancellationToken);

            //return new CreateAuthorCommandResponse(CreateAuthor) ;

            var BookToUpdate = await _BookRepository.GetBookByIdAsync(request.AuthorId, cancellationToken);
            if (BookToUpdate == null)
            {
                // Handle not found scenario, you could throw an exception or return a specific response  
                throw new KeyNotFoundException("Author not found");
            }

            // Update the author's properties  
            BookToUpdate.Title = request.Title;
            BookToUpdate.AuthorId = request.AuthorId;
            BookToUpdate.PublishedYear = request.PublishedYear;

            // Call the repository to update the author  
            _BookRepository.UpdateBookAsync(BookToUpdate);
            await _BookRepository.SaveChangesAsync(cancellationToken);
            return (UpdateBookCommandResponse)request ;


        }
    }
}
