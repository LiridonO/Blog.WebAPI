using FluentValidation;
using Models.DTOs.ForUpdateDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validators.ForUpdateValidator
{
    public class BlogFragmentsForUpdateValidator : AbstractValidator<BlogFragmentsForUpdateDTO>
    {
        public BlogFragmentsForUpdateValidator()
        {
            RuleFor(x => x.ImageTitle).NotNull().WithMessage("ImageTitle Required!");
            RuleFor(x => x.ImageDescription).NotNull().WithMessage("ImageDescription Required!");
            RuleFor(x => x.SubTitle).NotNull().WithMessage("SubTitle Required!");
            RuleFor(x => x.Content).NotNull().WithMessage("Content Required!");
        }
    }
}
