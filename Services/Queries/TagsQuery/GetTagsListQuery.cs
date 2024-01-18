using MediatR;
using Models.Models;
using Models.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries.TagsQuery
{
    public class GetTagsListQuery : IRequest<List<Tags>>
    {
        public TagsParams _tagsParams;

        public GetTagsListQuery(TagsParams tagsParams)
        {
            _tagsParams = tagsParams;
        }
    }
}
