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
    public class GetCommentsListHandler : IRequestHandler<GetCommentsListQuery, List<Comments>>
    {
        private readonly ICommentsRepository _repository;

        public GetCommentsListHandler(ICommentsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Comments>> Handle(GetCommentsListQuery request, CancellationToken cancellationToken)
        {
            var comments = await _repository.Get(request._commentsParams, "dbo.usp_CommentsSelect");
            return comments;
        }
    }
}
