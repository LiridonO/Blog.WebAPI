using MediatR;
using Models.DTOs;
using Models.DTOs.ForCreationDTO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.BlogsCommands
{
    public class InsertBlogsCommand : IRequest<DefaultResponse<Blogs>>
    {
        public BlogsForCreationDTO _blogsForCreationDTO;

        public InsertBlogsCommand(BlogsForCreationDTO blogsForCreationDTO)
        {
            _blogsForCreationDTO = blogsForCreationDTO;
        }
    }
}
