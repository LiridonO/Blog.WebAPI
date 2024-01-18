using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.BlogLikesCommands
{
    public class DeleteBlogLikesCommand : IRequest<bool>
    {
        public Guid _id { get; set; }
        public DeleteBlogLikesCommand(Guid id)
        {
            _id = id;
        }
    }
}
