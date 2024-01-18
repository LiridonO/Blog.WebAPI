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
    public class GetBlogsByIdHandler : IRequestHandler<GetBlogsByIdQuery, Blogs>
    {
        private readonly IBlogsRepository _blogsRepository;

        public GetBlogsByIdHandler(IBlogsRepository blogsRepository)
        {
            _blogsRepository = blogsRepository;
        }

        public async Task<Blogs> Handle(GetBlogsByIdQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogsRepository.GetById(request._id, "dbo.usp_BlogsSelect");
            return blogs;
        }
    }
}
