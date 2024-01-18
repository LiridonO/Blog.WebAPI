using FluentValidation;
using Models.DTOs.ForCreationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validators.ForCreationValidator
{
    public class DocumentsForCreationValidator : AbstractValidator<DocumentsForCreationDTO>
    {
        public DocumentsForCreationValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required");
        }
    }
}
