using MediatR;
using Models.Models;
using Repositories.IRepositories;
using Services.Queries.BlogsQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Handlers.BlogsHandlers
{
    public class GetBlogsListHandler : IRequestHandler<GetBlogsListQuery, List<Blogs>>
    {
        private readonly IBlogsRepository _blogsRepository;

        public GetBlogsListHandler(IBlogsRepository blogsRepository)
        {
            _blogsRepository = blogsRepository;
        }

        public async Task<List<Blogs>> Handle(GetBlogsListQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogsRepository.Get(request._blogsParams, "dbo.usp_BlogsSelect");
            return blogs;
        }
    }
}
