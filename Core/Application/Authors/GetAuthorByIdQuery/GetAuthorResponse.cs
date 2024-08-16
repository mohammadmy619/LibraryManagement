using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.GetAuthor
{
    public record GetAuthorResponse(Guid authorId, string Name)
    {
        public static explicit operator GetAuthorResponse(Author author)
            => new GetAuthorResponse(author.Id, author.Name);
    }



}
