using MediatR;
using Models.Models;
using Models.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries.BlogLikesQuery
{
    public class GetBlogLikesListQuery : IRequest<List<BlogLikes>>
    {
        public BlogLikesParams _blogLikesParams;

        public GetBlogLikesListQuery(BlogLikesParams blogLikesParams)
        {
            _blogLikesParams = blogLikesParams;
        }
    }
}
