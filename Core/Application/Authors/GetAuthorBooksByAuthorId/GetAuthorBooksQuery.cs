using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.GetAuthorBooksByAuthorId
{
    public record  GetAuthorBooksQuery(Guid authorId,int PageNumber = 1, int PageSize = 10) :IRequest<IReadOnlyCollection<GetAuthorBooksResponse>>;
    
}
