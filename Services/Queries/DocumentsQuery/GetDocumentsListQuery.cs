using MediatR;
using Models.Models;
using Models.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries.DocumentsQuery
{
    public class GetDocumentsListQuery : IRequest<List<Documents>>
    {
        public DocumentsParams _documentsParams;

        public GetDocumentsListQuery(DocumentsParams documentsParams)
        {
            _documentsParams = documentsParams;
        }
    }
}
