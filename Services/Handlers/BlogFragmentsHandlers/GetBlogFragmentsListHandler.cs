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
    public class GetBlogFragmentsListHandler : IRequestHandler<GetBlogFragmentsListQuery, List<BlogFragments>>
    {
        private readonly IBlogFragmentsRepository _blogFragmentsRepository;

        public GetBlogFragmentsListHandler(IBlogFragmentsRepository blogFragmentsRepository)
        {
            _blogFragmentsRepository = blogFragmentsRepository;
        }

        public async Task<List<BlogFragments>> Handle(GetBlogFragmentsListQuery request, CancellationToken cancellationToken)
        {
            var blogfragments = await _blogFragmentsRepository.Get(request._blogFragmentsParams, "dbo.usp_BlogFragmentsSelect");
            return blogfragments;
        }
    }
}
