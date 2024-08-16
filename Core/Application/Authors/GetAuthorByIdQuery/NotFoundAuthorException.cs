using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.GetAuthor
{
    public class NotFoundAuthorException : Exception
    {

        private const string _messages = "Author with AuthorId `{0}` not NotFound.";
       
        public NotFoundAuthorException(Guid AuthorId) :base(string.Format(_messages, AuthorId)) { }
    
    
    }
}
