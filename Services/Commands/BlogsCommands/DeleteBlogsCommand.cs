using MediatR;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.BlogsCommands
{
    public class DeleteBlogsCommand : IRequest<DefaultResponse<bool>>
    {
        public Guid _id { get; set; }
        public DeleteBlogsCommand(Guid id)
        {
            _id = id;
        }
    }
}
