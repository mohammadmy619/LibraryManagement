using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.GetAuthor
{
    public record GetAuthorByIdQuery(Guid AuthorId):IRequest<GetAuthorResponse>;
    
}
