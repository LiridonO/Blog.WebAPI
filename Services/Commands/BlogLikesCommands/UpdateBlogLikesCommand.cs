using MediatR;
using Models.DTOs.ForUpdateDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.BlogLikesCommands
{
    public class UpdateBlogLikesCommand : IRequest<bool>
    {
        public BlogLikesForUpdateDTO _blogLikesForUpdateDTO;

        public UpdateBlogLikesCommand(BlogLikesForUpdateDTO blogLikesForUpdateDTO)
        {
            _blogLikesForUpdateDTO = blogLikesForUpdateDTO;
        }
    }
}
