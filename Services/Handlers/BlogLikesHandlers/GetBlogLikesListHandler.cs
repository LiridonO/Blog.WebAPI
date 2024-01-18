using MediatR;
using Models.Models;
using Repositories.IRepositories;
using Services.Queries.BlogLikesQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Handlers.BlogLikesHandlers
{
    public class GetBlogLikesListHandler : IRequestHandler<GetBlogLikesListQuery, List<BlogLikes>>
    {
        private readonly IBlogLikesRepository _blogLikesRepository;

        public GetBlogLikesListHandler(IBlogLikesRepository blogLikesRepository)
        {
            _blogLikesRepository = blogLikesRepository;
        }

        public async Task<List<BlogLikes>> Handle(GetBlogLikesListQuery request, CancellationToken cancellationToken)
        {
            var blogLikes = await _blogLikesRepository.Get(request._blogLikesParams, "dbo.usp_BlogLikesSelect");
            return blogLikes;
        }
    }
}
