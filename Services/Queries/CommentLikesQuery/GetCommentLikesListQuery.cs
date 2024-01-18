using MediatR;
using Models.Models;
using Models.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries.CommentLikesQuery
{
    public class GetCommentLikesListQuery : IRequest<List<CommentLikes>>
    {
        public CommentLikesParams _commentLikesParams;

        public GetCommentLikesListQuery(CommentLikesParams commentLikesParams)
        {
            _commentLikesParams = commentLikesParams;
        }
    }
}
