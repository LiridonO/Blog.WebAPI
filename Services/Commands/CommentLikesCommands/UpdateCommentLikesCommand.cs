using MediatR;
using Models.DTOs.ForUpdateDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.CommentLikesCommands
{
    public class UpdateCommentLikesCommand : IRequest<bool>
    {
        public CommentLikesForUpdateDTO _commentLikesForUpdateDTO;

        public UpdateCommentLikesCommand(CommentLikesForUpdateDTO commentLikesForUpdateDTO)
        {
            _commentLikesForUpdateDTO = commentLikesForUpdateDTO;
        }
    }
}
