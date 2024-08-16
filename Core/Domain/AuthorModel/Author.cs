using Domain.BookModel;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AuthorModel
{
    public class Author:BaseEntity
    {

        
        public string Name { get; set; }

        public List<Book> Book { get; set; }

    }
}
