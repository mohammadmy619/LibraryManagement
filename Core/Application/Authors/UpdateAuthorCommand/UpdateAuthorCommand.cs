using Application.Authors.GetAuthor;
using Application.books.UpdateBookCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.UpdateAuthorCommand
{
    public record UpdateAuthorCommand(string Name,  Guid AuthorId) : IRequest<UpdateAuthorCommandResponse>;


}
