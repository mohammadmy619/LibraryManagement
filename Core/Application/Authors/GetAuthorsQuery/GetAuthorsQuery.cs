using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.GetAuthorsQuery
{
    public record  GetAuthorQuery(int PageNumber = 1, int PageSize = 10) :IRequest<IReadOnlyCollection<GetAuthoresponse>>;
    
}
