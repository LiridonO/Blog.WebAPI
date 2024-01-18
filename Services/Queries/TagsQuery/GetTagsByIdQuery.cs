using MediatR;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries.TagsQuery
{
    public class GetTagsByIdQuery : IRequest<Tags>
    {
        public Guid _id { get; set; }
        public GetTagsByIdQuery(Guid id)
        {
            _id = id;
        }
    }
}
