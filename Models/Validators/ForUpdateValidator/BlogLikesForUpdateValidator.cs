using FluentValidation;
using Models.DTOs.ForUpdateDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validators.ForUpdateValidator
{
    public class BlogLikesForUpdateValidator : AbstractValidator<BlogLikesForUpdateDTO>
    {
        public BlogLikesForUpdateValidator()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("UserId required");
            RuleFor(x => x.BlogEntityId).NotNull().WithMessage("BlogEntityId required");
        }
    }
}
