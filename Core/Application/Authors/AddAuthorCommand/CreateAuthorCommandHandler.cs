using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.AddAuthorCommand
{
    public class CreateAuthorCommandHandler(IAuthorRepository AuthorRepository) : IRequestHandler<CreateAuthorCommand, CreateAuthorCommandResponse>
    {
        private readonly IAuthorRepository _AuthorRepository = AuthorRepository;
        public async Task<CreateAuthorCommandResponse> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var CreateAuthor = await _AuthorRepository.AddAuthorAsync((Author)request, cancellationToken);
           await _AuthorRepository.SaveChangesAsync(cancellationToken);
            return new CreateAuthorCommandResponse(CreateAuthor) ;


        }
    }
}
