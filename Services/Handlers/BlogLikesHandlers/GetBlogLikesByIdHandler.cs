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
    public class GetBlogLikesByIdHandler : IRequestHandler<GetBlogLikesByIdQuery, BlogLikes>
    {
        private readonly IBlogLikesRepository _blogLikesRepository;

        public GetBlogLikesByIdHandler(IBlogLikesRepository blogLikesRepository)
        {
            _blogLikesRepository = blogLikesRepository;
        }

        public async Task<BlogLikes> Handle(GetBlogLikesByIdQuery request, CancellationToken cancellationToken)
        {
            var blogLikes = await _blogLikesRepository.GetById(request._id, "dbo.usp_BlogLikesSelect");
            return blogLikes;
        }
    }
}
