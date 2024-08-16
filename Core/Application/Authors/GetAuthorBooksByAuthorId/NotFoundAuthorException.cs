using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.GetAuthorBooksByAuthorId
{
    public class NotFoundAuthorException : Exception
    {

        private const string _messages = "Authors book not NotFound.";
       
        public NotFoundAuthorException() :base(_messages) { }
    
    
    }
}
