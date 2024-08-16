using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.GetAuthorsQuery
{
    public record GetAuthoresponse(Guid authorId, string Name)
    {
        public static explicit operator GetAuthoresponse(Author author)
            => new GetAuthoresponse(author.Id, author.Name);
    }



}
