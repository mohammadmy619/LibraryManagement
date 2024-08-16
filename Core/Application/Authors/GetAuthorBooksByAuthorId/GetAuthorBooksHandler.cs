using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.GetAuthorBooksByAuthorId
{
    public class GetAuthorBooksHandler(IAuthorRepository AuthorRepository) : IRequestHandler<GetAuthorBooksQuery, IReadOnlyCollection<GetAuthorBooksResponse>>
    {
        private readonly IAuthorRepository _AuthorRepository = AuthorRepository;
        public async Task<IReadOnlyCollection<GetAuthorBooksResponse>> Handle(GetAuthorBooksQuery request, CancellationToken cancellationToken)
        {
          var Author=await _AuthorRepository.GetAuthorBooksByAuthorId(request.authorId,request.PageNumber, request.PageSize, cancellationToken);


            if (Author is null)
            {
                throw new NotFoundAuthorException();
            }
            return [.. Author.Select(x => (GetAuthorBooksResponse)x)];
       

        }
        
    }
}
