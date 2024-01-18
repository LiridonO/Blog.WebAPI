using MediatR;
using Models.DTOs.ForUpdateDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.TagsCommands
{
    public class UpdateTagsCommand : IRequest<bool>
    {
        public TagsForUpdateDTO _tagsForUpdateDTO;

        public UpdateTagsCommand(TagsForUpdateDTO tagsForUpdateDTO)
        {
            _tagsForUpdateDTO = tagsForUpdateDTO;
        }
    }
}
