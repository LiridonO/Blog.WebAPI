using MediatR;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries.CommentLikesQuery
{
    public class GetCommentLikesByIdQuery : IRequest<CommentLikes>
    {
        public Guid _id { get; set; }
        public GetCommentLikesByIdQuery(Guid id)
        {
            _id = id;
        }
    }
}
