using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.books.UpdateBookCommand
{
    public record UpdateBookCommandResponse(string Title, int PublishedYear, Guid AuthorId)
    {
        public static explicit operator UpdateBookCommandResponse(UpdateBookCommand author)
            => new UpdateBookCommandResponse(author.Title, author.PublishedYear, author.AuthorId);
    };

}
