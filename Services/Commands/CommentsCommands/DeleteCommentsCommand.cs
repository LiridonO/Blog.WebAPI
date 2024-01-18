using MediatR;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.CommentsCommands
{
    public class DeleteCommentsCommand : IRequest<DefaultResponse<bool>>
    {
        public Guid _id { get; set; }
        public DeleteCommentsCommand(Guid id)
        {
            _id = id;
        }
    }
}
