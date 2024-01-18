using MediatR;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.BlogFragmentsCommands
{
    public class DeleteBlogFragmentsCommand : IRequest<DefaultResponse<bool>>
    {
        public Guid _id { get; set; }
        public DeleteBlogFragmentsCommand(Guid id)
        {
            _id = id;
        }
    }
}
