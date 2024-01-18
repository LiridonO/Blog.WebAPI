using MediatR;
using Models.Models;
using Models.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries.BlogsQuery
{
    public class GetBlogsListQuery : IRequest<List<Blogs>>
    {
        public BlogsParams _blogsParams;

        public GetBlogsListQuery(BlogsParams blogsParams)
        {
            _blogsParams = blogsParams;
        }
    }
}
