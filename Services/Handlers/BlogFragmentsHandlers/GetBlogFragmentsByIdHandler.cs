using MediatR;
using Models.Models;
using Repositories.IRepositories;
using Services.Queries.BlogFragmentsQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Handlers.BlogFragmentsHandlers
{
    public class GetBlogFragmentsByIdHandler : IRequestHandler<GetBlogFragmentsByIdQuery, BlogFragments>
    {
        private readonly IBlogFragmentsRepository _blogFragmentsrepository;

        public GetBlogFragmentsByIdHandler(IBlogFragmentsRepository blogFragmentsrepository)
        {
            _blogFragmentsrepository = blogFragmentsrepository;
        }

        public async Task<BlogFragments> Handle(GetBlogFragmentsByIdQuery request, CancellationToken cancellationToken)
        {
            var blogfragments = await _blogFragmentsrepository.GetById(request._id, "dbo.usp_BlogFragmentsSelect");
            return blogfragments;
        }
    }
}
