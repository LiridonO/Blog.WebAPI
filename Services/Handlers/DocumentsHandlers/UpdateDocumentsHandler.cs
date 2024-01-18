using MediatR;
using Microsoft.AspNetCore.Http;
using Models.Exceptions;
using Models.Validators.ForUpdateValidator;
using Repositories.IRepositories;
using Services.Commands.DocumentsCommands;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Services.Handlers.DocumentsHandlers
{
    public class UpdateDocumentsHandler : IRequestHandler<UpdateDocumentsCommand, bool>
    {
        private readonly IDocumentsRepository _DocumentsRepository;
        private readonly SqlConnection _sqlConnection;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateDocumentsHandler(IDocumentsRepository DocumentsRepository, SqlConnection sqlConnection, IHttpContextAccessor httpContextAccessor)
        {
            _DocumentsRepository = DocumentsRepository;
            _sqlConnection = sqlConnection;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> Handle(UpdateDocumentsCommand request, CancellationToken cancellationToken)
        {
            DocumentsForUpdateValidator validator = new DocumentsForUpdateValidator();
            FluentValidation.Results.ValidationResult results = await validator.ValidateAsync(request._documentsForUpdateDTO);

            if (results.Errors.Count > 0)
            {
                throw new ValidationException(results);
            }


            _sqlConnection.Open();

            var tran = _sqlConnection.BeginTransaction();

            try
            {
                var id = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
                request._documentsForUpdateDTO.LastEditedBy = Guid.Parse(id);

                var entity = await _DocumentsRepository.Update(request._documentsForUpdateDTO, "dbo.usp_DocumentsUpdate", _sqlConnection, tran);
                tran.Commit();
                return entity;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
    }
}
