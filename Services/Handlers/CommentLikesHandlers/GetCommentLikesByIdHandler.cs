using MediatR;
using Models.Models;
using Repositories.IRepositories;
using Services.Queries.CommentLikesQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Handlers.CommentLikesHandlers
{
    public class GetCommentLikesByIdHandler : IRequestHandler<GetCommentLikesByIdQuery, CommentLikes>
    {
        private readonly ICommentLikesRepository _commentLikesRepository;

        public GetCommentLikesByIdHandler(ICommentLikesRepository commentLikesRepository)
        {
            _commentLikesRepository = commentLikesRepository;
        }

        public async Task<CommentLikes> Handle(GetCommentLikesByIdQuery request, CancellationToken cancellationToken)
        {
            var commentLikes = await _commentLikesRepository.GetById(request._id, "dbo.usp_CommentLikesSelect");
            return commentLikes;
        }
    }
}
