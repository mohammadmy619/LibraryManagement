using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.books.GetBookByIdQuery
{

    public record GetBookByIdQuery(Guid BookId) :IRequest<GetBookResponse>;
    
}
