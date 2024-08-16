using Domain.AuthorModel;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BookModel
{
    public class Book: BaseEntity
    {

     
        public string Title { get; set; }
        public int PublishedYear { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }


    }
}
