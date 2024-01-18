using MediatR;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries.BlogFragmentsQuery
{
    public class GetBlogFragmentsByIdQuery : IRequest<BlogFragments>
    {
        public Guid _id { get; set; }
        public GetBlogFragmentsByIdQuery(Guid id)
        {
            _id = id;
        }
    }
}
