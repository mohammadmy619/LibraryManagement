using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.books.AddBookCommand
{
    public record CreateBookCommandResponse(Guid BookId)
    {
        public static explicit operator CreateBookCommandResponse(Guid BookId)
            => new CreateBookCommandResponse(BookId);
    };

}
