using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.UpdateAuthorCommand
{
    public class UpdateAuthorCommandValidation : AbstractValidator<UpdateAuthorCommand>
    {

        public UpdateAuthorCommandValidation()
        {
            RuleFor(a => a.Name)
          .NotEmpty().WithMessage("{Name} is required")
          .NotNull()
          .MaximumLength(100).WithMessage("{Name} must not exceed 100 characters");

            RuleFor(a => a.AuthorId)
     .NotEmpty().WithMessage("{AuthorId} is required");


        }
    }
}
