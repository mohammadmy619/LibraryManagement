﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.books.AddBookCommand
{
    public class CreateBookCommandValidation : AbstractValidator<CreateBookCommand>
    {

        public CreateBookCommandValidation()
        {
            RuleFor(a => a.Title)
          .NotEmpty().WithMessage("{Title} is required")
          .NotNull()
          .MaximumLength(100).WithMessage("{Title} must not exceed 100 characters");

            RuleFor(a => a.AuthorId)
            .NotEmpty().WithMessage("{AuthorId} is required")
             .NotNull();

        }
    }
}