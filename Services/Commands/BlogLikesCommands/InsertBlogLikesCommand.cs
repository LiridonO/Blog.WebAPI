using MediatR;
using Models.DTOs.ForCreationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.BlogLikesCommands
{
    public class InsertBlogLikesCommand : IRequest<BlogLikesForCreationDTO>
    {
        public BlogLikesForCreationDTO _blogLikesForCreationDTO;

        public InsertBlogLikesCommand(BlogLikesForCreationDTO blogLikesForCreationDTO)
        {
            _blogLikesForCreationDTO = blogLikesForCreationDTO;
        }
    }
}
