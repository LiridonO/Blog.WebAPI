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
    public class GetDocumentsByIdHandler : IRequestHandler<GetDocumentsByIdQuery,Documents>
    {
        private readonly IDocumentsRepository _documentsRepository;

        public GetDocumentsByIdHandler(IDocumentsRepository documentsRepository)
        {
            _documentsRepository = documentsRepository;
        }

        public async Task<Documents> Handle(GetDocumentsByIdQuery request, CancellationToken cancellationToken)
        {
            var documents = await _documentsRepository.GetById(request._id, "dbo.usp_DocumentsSelect");
            return documents;
        }
    }
}
