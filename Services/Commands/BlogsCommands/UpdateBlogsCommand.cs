using MediatR;
using Models.DTOs.ForUpdateDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.BlogsCommands
{
    public class UpdateBlogsCommand : IRequest<bool>
    {
        public BlogsForUpdateDTO _blogsForUpdateDTO;

        public UpdateBlogsCommand(BlogsForUpdateDTO blogsForUpdateDTO)
        {
            _blogsForUpdateDTO = blogsForUpdateDTO;
        }
    }
}
