using MediatR;
using Models.DTOs;
using Models.DTOs.ForCreationDTO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.CommentsCommands
{
    public class InsertCommentsCommand : IRequest<DefaultResponse<Comments>>
    {
        public CommentsForCreationDTO _commentsForCreationDTO;

        public InsertCommentsCommand(CommentsForCreationDTO commentsForCreationDTO)
        {
            _commentsForCreationDTO = commentsForCreationDTO;
        }
    }
}
