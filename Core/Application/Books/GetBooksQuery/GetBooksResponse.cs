using Application.Authors.GetAuthorsQuery;
using Domain.BookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.books.GetBooksQuery
{
    public record GetBooksResponse(Guid authorId, string Title,int PublishedYear)
    {
        public static explicit operator GetBooksResponse(Book book)
            => new GetBooksResponse(book.Id, book.Title, book.PublishedYear);

      
    }



}
