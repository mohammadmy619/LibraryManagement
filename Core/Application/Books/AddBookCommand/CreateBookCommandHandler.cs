using Application.Authors.GetAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.books.AddBookCommand
{
    public class CreateBookCommandHandler(IBookRepository BookRepository,IAuthorRepository AuthorRepository) : IRequestHandler<CreateBookCommand, CreateBookCommandResponse>
    {
        private readonly IBookRepository _BookRepository = BookRepository;
        private readonly IAuthorRepository _AuthorRepository = AuthorRepository;
        public async Task<CreateBookCommandResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {

            var Author = await _AuthorRepository.GetAuthorByIdAsync(request.AuthorId, cancellationToken);
            if (Author is null)
            {
               throw new NotFoundAuthorException(request.AuthorId);
            }
                var res= await _BookRepository.AddBookAsync((Book)request, cancellationToken);
         
            await _BookRepository.SaveChangesAsync(cancellationToken);
            return new CreateBookCommandResponse(res) ;


        }
    }
}
