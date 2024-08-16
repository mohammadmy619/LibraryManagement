using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.books.GetBooksQuery
{
    public record  GetBooksQuery(int PageNumber = 1, int PageSize = 10) :IRequest<IReadOnlyCollection<GetBooksResponse>>;
    
}
