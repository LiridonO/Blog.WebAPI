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
    public class GetTagsListHandler : IRequestHandler<GetTagsListQuery, List<Tags>>
    {
        private readonly ITagsRepository _tagsRepository;

        public GetTagsListHandler(ITagsRepository tagsRepository)
        {
            _tagsRepository = tagsRepository;
        }

        public async Task<List<Tags>> Handle(GetTagsListQuery request, CancellationToken cancellationToken)
        {
            var tags = await _tagsRepository.Get(request._tagsParams, "dbo.usp_TagsSelect");
            return tags;
        }
    }
}
