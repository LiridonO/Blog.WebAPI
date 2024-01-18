using MediatR;
using Models.DTOs.ForUpdateDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.BlogFragmentsCommands
{
    public class UpdateBlogFragmentsCommand : IRequest<bool>
    {
        public BlogFragmentsForUpdateDTO _blogFragmentsForUpdateDTO;

        public UpdateBlogFragmentsCommand(BlogFragmentsForUpdateDTO blogFragmentsForUpdateDTO)
        {
            _blogFragmentsForUpdateDTO = blogFragmentsForUpdateDTO;
        }
    }
}
