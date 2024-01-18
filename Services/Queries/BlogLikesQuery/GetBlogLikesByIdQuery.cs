using MediatR;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries.BlogLikesQuery
{
    public class GetBlogLikesByIdQuery : IRequest<BlogLikes>
    {
        public Guid _id { get; set; }

        public GetBlogLikesByIdQuery(Guid id)
        {
            _id = id;
        }
    }
}
