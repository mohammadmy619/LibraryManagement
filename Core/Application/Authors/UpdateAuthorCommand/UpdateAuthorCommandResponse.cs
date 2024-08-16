using Application.Authors.UpdateAuthorCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.books.UpdateBookCommand
{
    public record UpdateAuthorCommandResponse
    {
        public UpdateAuthorCommand UpdatedAuthor { get; }

        public UpdateAuthorCommandResponse(UpdateAuthorCommand updatedAuthor)
        {
            UpdatedAuthor = updatedAuthor ?? throw new ArgumentNullException(nameof(updatedAuthor));
        }
    }
}
