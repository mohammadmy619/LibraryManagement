using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.GetAuthorsQuery
{
    public class GetAuthorHandler(IAuthorRepository AuthorRepository) : IRequestHandler<GetAuthorQuery, IReadOnlyCollection<GetAuthoresponse>>
    {
        private readonly IAuthorRepository _AuthorRepository = AuthorRepository;
        public async Task<IReadOnlyCollection<GetAuthoresponse>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
          var Author=await _AuthorRepository.GetAuthorsAsync(request.PageNumber, request.PageSize, cancellationToken);


            if (Author is null)
            {
                throw new NotFoundAuthorException();
            }
            return [.. Author.Select(x => (GetAuthoresponse)x)];
       

        }
        
    }
}
