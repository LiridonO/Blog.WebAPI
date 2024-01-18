using FluentValidation;
using Models.DTOs.ForUpdateDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validators.ForUpdateValidator
{
    public class CommentsForUpdateValidator : AbstractValidator<CommentsForUpdateDTO>
    {
        public CommentsForUpdateValidator()
        {
            RuleFor(x => x.Content).NotNull().WithMessage("Content is required!");
        }
    }
}
