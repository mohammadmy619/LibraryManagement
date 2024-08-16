using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.GetAuthor
{
    public class GetAuthorsHandler(IAuthorRepository AuthorRepository) : IRequestHandler<GetAuthorByIdQuery, GetAuthorResponse>
    {
        private readonly IAuthorRepository _AuthorRepository = AuthorRepository;
        public async Task<GetAuthorResponse> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
          var Author=await _AuthorRepository.GetAuthorByIdAsync(request.AuthorId, cancellationToken);


            if (Author is null)
            {
                throw new NotFoundAuthorException(request.AuthorId);
            }
            
            return (GetAuthorResponse)Author;

        }
        
    }
}
