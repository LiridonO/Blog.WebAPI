using MediatR;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries.CommentsQuery
{
    public class GetCommentsByIdQuery : IRequest<Comments>
    {
        public Guid _id { get; set; }
        public GetCommentsByIdQuery(Guid id)
        {
            _id = id;
        }
    }
}
