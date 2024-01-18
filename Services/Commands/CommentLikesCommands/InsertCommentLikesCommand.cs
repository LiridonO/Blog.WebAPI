using MediatR;
using Models.DTOs.ForCreationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.CommentLikesCommands
{
    public class InsertCommentLikesCommand : IRequest<CommentLikesForCreationDTO>
    {
        public CommentLikesForCreationDTO _commentLikesForCreationDTO;

        public InsertCommentLikesCommand(CommentLikesForCreationDTO commentLikesForCreationDTO)
        {
            _commentLikesForCreationDTO = commentLikesForCreationDTO;   
        }
    }
}
