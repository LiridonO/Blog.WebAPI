using MediatR;
using Models.Models;
using Repositories.IRepositories;
using Services.Queries.CommentsQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Handlers.CommentsHandlers
{
    public class GetCommentsByIdHandler : IRequestHandler<GetCommentsByIdQuery, Comments>
    {
        private readonly ICommentsRepository _commentsRepository;

        public GetCommentsByIdHandler(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public async Task<Comments> Handle(GetCommentsByIdQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentsRepository.GetById(request._id, "dbo.usp_CommentsSelect");
            return comments;
        }
    }
}
