using MediatR;
using Models.DTOs;
using Models.DTOs.ForCreationDTO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.TagsCommands
{
    public class InsertTagsCommand : IRequest<DefaultResponse<Tags>>
    {
        public TagsForCreationDTO _tagsForCreationDTO;

        public InsertTagsCommand(TagsForCreationDTO tagsForCreationDTO)
        {
            _tagsForCreationDTO = tagsForCreationDTO;
        }
    }
}
