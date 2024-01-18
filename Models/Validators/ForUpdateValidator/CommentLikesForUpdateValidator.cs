using FluentValidation;
using Models.DTOs.ForUpdateDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validators.ForUpdateValidator
{
    public class CommentLikesForUpdateValidator : AbstractValidator<CommentLikesForUpdateDTO>
    {
        public CommentLikesForUpdateValidator()
        {
            RuleFor(x => x.CommentId).NotNull().WithMessage("CommentId required!");
            RuleFor(x => x.UserId).NotNull().WithMessage("UserId required!");
        }
    }
}
