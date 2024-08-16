using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.books.GetBooksQuery
{
    public class GetBooksException : Exception
    {

        private const string _messages = "Book not NotFound.";
       
        public GetBooksException() :base(string.Format(_messages)) { }
    
    
    }
}
