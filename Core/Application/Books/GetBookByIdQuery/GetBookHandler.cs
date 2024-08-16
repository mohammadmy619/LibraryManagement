
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.books.GetBookByIdQuery
{
    public class GetBookHandler(IBookRepository BookRepository) : IRequestHandler<GetBookByIdQuery, GetBookResponse>
    {
        private readonly IBookRepository _BookRepository = BookRepository;
        public async Task<GetBookResponse> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
          var book=await _BookRepository.GetBookByIdAsync(request.BookId, cancellationToken);


            if (book is null)
            {
                throw new GetBookException(request.BookId);
            }
            
            return (GetBookResponse)book;

        }
        
    }
}
