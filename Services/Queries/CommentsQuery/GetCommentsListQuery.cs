using MediatR;
using Models.Models;
using Models.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries.CommentsQuery
{
    public class GetCommentsListQuery : IRequest<List<Comments>>
    {
        public CommentsParams _commentsParams;

        public GetCommentsListQuery(CommentsParams commentsParams)
        {
            _commentsParams = commentsParams;
        }
    }
}
