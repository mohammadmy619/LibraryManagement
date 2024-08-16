using Application.books.GetBookByIdQuery;
using Application.books.GetBooksQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.books.GetBooksQuery
{
    public class GetBooksHandler(IBookRepository BookRepository) : IRequestHandler<GetBooksQuery, IReadOnlyCollection<GetBooksResponse>>
    {
        private readonly IBookRepository _BookRepository = BookRepository;
        public async Task<IReadOnlyCollection<GetBooksResponse>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
          var book=await _BookRepository.GetBooksAsync(request.PageNumber, request.PageSize, cancellationToken);


            if (book is null)
            {
                throw new GetBooksException();
            }

            return [.. book.Select(x => (GetBooksResponse)x)];
         


        }
        
    }
}
