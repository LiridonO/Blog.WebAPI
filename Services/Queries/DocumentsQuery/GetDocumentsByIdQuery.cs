using MediatR;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries.DocumentsQuery
{
    public class GetDocumentsByIdQuery : IRequest<Documents>
    {
        public Guid _id { get; set; }

        public GetDocumentsByIdQuery(Guid id)
        {
            _id = id;
        }
    }
}
