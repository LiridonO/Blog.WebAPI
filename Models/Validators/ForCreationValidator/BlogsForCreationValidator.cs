using FluentValidation;
using Models.DTOs.ForCreationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validators.ForCreationValidator
{
    public class BlogsForCreationValidator : AbstractValidator<BlogsForCreationDTO>
    {
        public BlogsForCreationValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("Title is required!");
            RuleFor(x => x.ShortDescription).NotNull().WithMessage("ShortDescription is required!");
        }
    }
}
