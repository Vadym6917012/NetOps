using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetOps.Application.Requests.Commands
{
    public sealed class CreateRequestCommandValidator
        : AbstractValidator<CreateRequestCommand>
    {
        public CreateRequestCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(2000);
            
            RuleFor(x => x.Priority)
                .IsInEnum();
        }
    }
}
