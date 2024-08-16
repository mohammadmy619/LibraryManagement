using Application.Authors.GetAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.books.UpdateBookCommand
{
   
    public record UpdateBookCommand(string Title, int PublishedYear,Guid AuthorId) : IRequest<UpdateBookCommandResponse>
    {
        public static explicit operator Book(UpdateBookCommand author)
    => new Book()
    {
        Title = author.Title,
        AuthorId = author.AuthorId,
        PublishedYear = author.PublishedYear,
    };
};



}
