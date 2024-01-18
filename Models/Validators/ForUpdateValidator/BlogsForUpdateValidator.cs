using FluentValidation;
using Models.DTOs.ForUpdateDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validators.ForUpdateValidator
{
    public class BlogsForUpdateValidator : AbstractValidator<BlogsForUpdateDTO>
    {
        public BlogsForUpdateValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("Title is required!");
        }
    }
}
