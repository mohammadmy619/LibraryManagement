using Domain.BookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.GetAuthorBooksByAuthorId
{

    public record GetAuthorBooksResponse(Guid BookId, string Title, int PublishedYear, Guid authorId)
    {
        public static explicit operator GetAuthorBooksResponse(Book Book)
            => new GetAuthorBooksResponse(Book.Id, Book.Title, Book.PublishedYear,Book.AuthorId);
    }



}
