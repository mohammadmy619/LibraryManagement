using Application.Authors.GetAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.books.AddBookCommand
{
   
    public record CreateBookCommand(string Title, int PublishedYear,Guid AuthorId) : IRequest<CreateBookCommandResponse>
    {
        public static explicit operator Book(CreateBookCommand author)
    => new Book()
    {
        Title = author.Title,
        AuthorId = author.AuthorId,
        PublishedYear = author.PublishedYear,
    };
};



}
