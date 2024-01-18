using MediatR;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.TagsCommands
{
    public class DeleteTagsCommand : IRequest<DefaultResponse<bool>>
    {
        public Guid _id { get; set; }

        public DeleteTagsCommand(Guid id)
        {
            _id = id;
        }
    }
}
