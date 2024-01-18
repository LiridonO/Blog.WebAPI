using MediatR;
using Microsoft.AspNetCore.Http;
using Models.DTOs;
using Models.DTOs.ForCreationDTO;
using Models.Exceptions;
using Models.Models;
using Models.Validators.ForCreationValidator;
using Repositories.IRepositories;
using Services.Commands.DocumentsCommands;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.Handlers.DocumentsHandlers
{
    public class InsertDocumentsHandler : IRequestHandler<InsertDocumentsCommand, DefaultResponse<Documents>>
    {
        private readonly IDocumentsRepository _repository;
        private readonly SqlConnection _cnn;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InsertDocumentsHandler(IDocumentsRepository repository, SqlConnection cnn, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _cnn = cnn;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<DefaultResponse<Documents>> Handle(InsertDocumentsCommand request, CancellationToken cancellationToken)
        {
            var id = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;

            DocumentsForCreationValidator validator = new DocumentsForCreationValidator();
            FluentValidation.Results.ValidationResult results = await validator.ValidateAsync(request._documentsForCreationDTO);

            if(results.Errors.Count > 0)
            {
                throw new ValidationException(results);
            }

            _cnn.Open();

            var tran = _cnn.BeginTransaction();

            try
            {
                request._documentsForCreationDTO.InsertedBy = Guid.Parse(id);
                var entity = await _repository.Insert(request._documentsForCreationDTO, "dbo.usp_DocumentsInsert", _cnn, tran);
                tran.Commit();

                return new DefaultResponse<Documents>
                {
                    Data = entity,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                _cnn.Close();
            }
        }
    }
}
