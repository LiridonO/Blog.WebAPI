using MediatR;
using Models.DTOs;
using Models.DTOs.ForCreationDTO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.BlogFragmentsCommands
{
    public class InsertBlogFragmentsCommand : IRequest<DefaultResponse<BlogFragments>>
    {
        public BlogFragmentsForCreationDTO _blogFragmentsForCreationDTO;

        public InsertBlogFragmentsCommand(BlogFragmentsForCreationDTO blogFragmentsForCreationDTO)
        {
            _blogFragmentsForCreationDTO = blogFragmentsForCreationDTO;
        }
    }
}
