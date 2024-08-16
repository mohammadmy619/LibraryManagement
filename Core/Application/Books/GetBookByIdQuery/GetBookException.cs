using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.books.GetBookByIdQuery
{
    public class GetBookException : Exception
    {

        private const string _messages = "Book with BookId `{0}` not NotFound.";
       
        public GetBookException(Guid BookId) :base(string.Format(_messages, BookId)) { }
    
    
    }
}
