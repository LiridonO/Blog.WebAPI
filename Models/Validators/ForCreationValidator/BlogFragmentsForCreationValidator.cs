using FluentValidation;
using Models.DTOs.ForCreationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validators.ForCreationValidator
{
    public class BlogFragmentsForCreationValidator : AbstractValidator<BlogFragmentsForCreationDTO>
    {
        public BlogFragmentsForCreationValidator()
        {
            RuleFor(x => x.BlogEntityId).NotNull().WithMessage("BlogEntityId Required!");
            RuleFor(x => x.ImageTitle).NotNull().WithMessage("ImageTitle Required!");
            RuleFor(x => x.ImageDescription).NotNull().WithMessage("ImageDescription Required!");
            RuleFor(x => x.SubTitle).NotNull().WithMessage("SubTitle Required!");
            RuleFor(x => x.Content).NotNull().WithMessage("Content Required!");
        }
    }
}
