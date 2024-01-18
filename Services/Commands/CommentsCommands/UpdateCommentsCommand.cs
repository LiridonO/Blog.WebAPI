using MediatR;
using Models.DTOs.ForUpdateDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.CommentsCommands
{
    public class UpdateCommentsCommand : IRequest<bool>
    {
        public CommentsForUpdateDTO _commentsForUpdateDTO;

        public UpdateCommentsCommand(CommentsForUpdateDTO commentsForUpdateDTO)
        {
            _commentsForUpdateDTO = commentsForUpdateDTO;
        }
    }
}
