using MediatR;
using Models.Models;
using Models.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries.BlogFragmentsQuery
{
    public class GetBlogFragmentsListQuery : IRequest<List<BlogFragments>>
    {
        public BlogFragmentsParams _blogFragmentsParams;

        public GetBlogFragmentsListQuery(BlogFragmentsParams blogFragmentsParams)
        {
            _blogFragmentsParams = blogFragmentsParams;
        }
    }
}
