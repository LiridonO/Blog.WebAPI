using FluentValidation;
using Models.DTOs.ForUpdateDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validators.ForUpdateValidator
{
    public class DocumentsForUpdateValidator : AbstractValidator<DocumentsForUpdateDTO>
    {
        public DocumentsForUpdateValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required!");
        }
    }
}
