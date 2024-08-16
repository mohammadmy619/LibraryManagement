using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.AddAuthorCommand
{
    public record CreateAuthorCommandResponse(Guid AuthorId)
    {
        public static explicit operator CreateAuthorCommandResponse(Guid AuthorId)
            => new CreateAuthorCommandResponse(AuthorId);
    };

}
