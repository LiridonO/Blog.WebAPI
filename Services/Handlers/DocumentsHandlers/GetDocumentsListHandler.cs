using MediatR;
using Models.Models;
using Repositories.IRepositories;
using Services.Queries.DocumentsQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Handlers.DocumentsHandlers
{
    public class GetDocumentsListHandler : IRequestHandler<GetDocumentsListQuery, List<Documents>>
    {
        private readonly IDocumentsRepository _documentsRepository;

        public GetDocumentsListHandler(IDocumentsRepository documentsRepository)
        {
            _documentsRepository = documentsRepository;
        }

        public async Task<List<Documents>> Handle(GetDocumentsListQuery request,CancellationToken cancellationToken)
        {
            var documents = await _documentsRepository.Get(request._documentsParams, "dbo.usp_DocumentsSelect");
            return documents;
        }
    }
}
