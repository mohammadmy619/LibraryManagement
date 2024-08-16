using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.GetAuthorsQuery
{
    public class NotFoundAuthorException : Exception
    {

        private const string _messages = "Authors not NotFound.";
       
        public NotFoundAuthorException() :base(_messages) { }
    
    
    }
}
