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
    public class GetCommentLikesListHandler : IRequestHandler<GetCommentLikesListQuery, List<CommentLikes>>
    {
        private readonly ICommentLikesRepository _repository;

        public GetCommentLikesListHandler(ICommentLikesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CommentLikes>> Handle(GetCommentLikesListQuery request, CancellationToken cancellationToken)
        {
            var commentLikes = await _repository.Get(request._commentLikesParams, "dbo.usp_CommentLikesSelect");
            return commentLikes;
        }
    }
}
