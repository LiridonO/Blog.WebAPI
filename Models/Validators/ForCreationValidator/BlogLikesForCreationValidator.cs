using FluentValidation;
using Models.DTOs.ForCreationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validators.ForCreationValidator
{
    public class BlogLikesForCreationValidator : AbstractValidator<BlogLikesForCreationDTO>
    {
        public BlogLikesForCreationValidator()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("UserId required");
            RuleFor(x => x.BlogEntityId).NotNull().WithMessage("BlogEntityId required");
        }
    }
}
