using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.AddAuthorCommand
{
    public class CreateAuthorCommandValidation : AbstractValidator<CreateAuthorCommand>
    {

        public CreateAuthorCommandValidation()
        {
            RuleFor(a => a.Name)
          .NotEmpty().WithMessage("{Name} is required")
          .NotNull()
          .MaximumLength(100).WithMessage("{Name} must not exceed 100 characters");
        }
    }
}
