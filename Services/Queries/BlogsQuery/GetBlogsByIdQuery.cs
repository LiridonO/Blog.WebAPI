using MediatR;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries.BlogsQuery
{
    public class GetBlogsByIdQuery : IRequest<Blogs>
    {
        public Guid _id { get; set; }
        public GetBlogsByIdQuery(Guid id)
        {
            _id = id;
        }
    }
}
