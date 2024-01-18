using FluentValidation;
using Models.DTOs.ForCreationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validators.ForCreationValidator
{
    public class CommentsForCreationValidator : AbstractValidator<CommentsForCreationDTO>
    {
        public CommentsForCreationValidator()
        {
            RuleFor(x => x.Content).NotNull().WithMessage("Content is required!");
        }
    }
}
