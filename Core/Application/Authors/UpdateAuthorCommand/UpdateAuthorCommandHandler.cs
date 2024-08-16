using Application.books.UpdateBookCommand;
using Domain.AuthorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.UpdateAuthorCommand
{
    public class UpdateAuthorCommandHandler(IAuthorRepository AuthorRepository) : IRequestHandler<UpdateAuthorCommand, UpdateAuthorCommandResponse>
    {
        private readonly IAuthorRepository _AuthorRepository = AuthorRepository;
        public async Task<UpdateAuthorCommandResponse> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {

          
            var authorToUpdate = await _AuthorRepository.GetAuthorByIdAsync(request.AuthorId, cancellationToken);
            if (authorToUpdate == null)
            {
                // Handle not found scenario, you could throw an exception or return a specific response  
                throw new KeyNotFoundException("Author not found");
            }

            // Update the author's properties  
            authorToUpdate.Name = request.Name;

            // Call the repository to update the author  
           _AuthorRepository.UpdateAuthorAsync(authorToUpdate);
            await _AuthorRepository.SaveChangesAsync(cancellationToken);
            return new UpdateAuthorCommandResponse(request);

;


        }
    }
}
