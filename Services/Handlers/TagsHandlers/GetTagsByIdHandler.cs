using MediatR;
using Models.Models;
using Repositories.IRepositories;
using Services.Queries.TagsQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Handlers.TagsHandlers
{
    public class GetTagsByIdHandler : IRequestHandler<GetTagsByIdQuery,Tags>
    {
        private readonly ITagsRepository _tagsRepository;

        public GetTagsByIdHandler(ITagsRepository tagsRepository)
        {
            _tagsRepository = tagsRepository;
        }

        public async Task<Tags> Handle(GetTagsByIdQuery request, CancellationToken cancellationToken)
        {
            var tags = await _tagsRepository.GetById(request._id, "dbo.usp_TagsSelect");
            return tags;
        }
    }
}
