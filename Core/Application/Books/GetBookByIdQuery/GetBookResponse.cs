using Domain.BookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.books.GetBookByIdQuery
{
    public record GetBookResponse(Guid authorId, string Title,int PublishedYear)
    {
        public static explicit operator GetBookResponse(Book book)
            => new GetBookResponse(book.Id, book.Title, book.PublishedYear);
    }



}
