using MediatR;
using Models.DTOs.ForUpdateDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.DocumentsCommands
{
    public class UpdateDocumentsCommand : IRequest<bool>
    {
        public DocumentsForUpdateDTO _documentsForUpdateDTO;

        public UpdateDocumentsCommand(DocumentsForUpdateDTO documentsForUpdateDTO)
        {
            _documentsForUpdateDTO = documentsForUpdateDTO;
        }
    }
}
