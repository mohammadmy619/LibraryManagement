using Application.Authors.GetAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.AddAuthorCommand
{
    public record CreateAuthorCommand(string Name) : IRequest<CreateAuthorCommandResponse>
    {
        public static explicit operator Author(CreateAuthorCommand author)
            =>  new Author()
    {
        Name = author.Name,



    };
};



}
