using FluentValidation;
using Models.DTOs.ForCreationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validators.ForCreationValidator
{
    public class CommentLikesForCreationValidator : AbstractValidator<CommentLikesForCreationDTO>
    {
        public CommentLikesForCreationValidator()
        {
            RuleFor(x => x.CommentId).NotNull().WithMessage("CommentId required!");
            RuleFor(x => x.UserId).NotNull().WithMessage("UserId required!");
        }
    }
}
