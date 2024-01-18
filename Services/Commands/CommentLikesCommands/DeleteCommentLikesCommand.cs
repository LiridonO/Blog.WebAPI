using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.CommentLikesCommands
{
    public class DeleteCommentLikesCommand : IRequest<bool>
    {
        public Guid _id { get; set; }
        public DeleteCommentLikesCommand(Guid id)
        {
            _id = id;
        }
    }
}
