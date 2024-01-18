using MediatR;
using Models.DTOs;
using Models.DTOs.ForCreationDTO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.DocumentsCommands
{
    public class InsertDocumentsCommand : IRequest<DefaultResponse<Documents>>
    {
        public DocumentsForCreationDTO _documentsForCreationDTO;

        public InsertDocumentsCommand(DocumentsForCreationDTO documentsForCreationDTO)
        {
            _documentsForCreationDTO = documentsForCreationDTO;
        }
    }
}
