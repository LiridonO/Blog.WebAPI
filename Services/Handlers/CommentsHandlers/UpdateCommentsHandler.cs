using MediatR;
using Microsoft.AspNetCore.Http;
using Models.Exceptions;
using Models.Validators.ForUpdateValidator;
using Repositories.IRepositories;
using Services.Commands.CommentsCommands;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Services.Handlers.CommentsHandlers
{
    public class UpdateCommentsHandler : IRequestHandler<UpdateCommentsCommand, bool>
    {
        private readonly ICommentsRepository _CommentsRepository;
        private readonly SqlConnection _sqlConnection;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateCommentsHandler(ICommentsRepository CommentsRepository, SqlConnection sqlConnection, IHttpContextAccessor httpContextAccessor)
        {
            _CommentsRepository = CommentsRepository;
            _sqlConnection = sqlConnection;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> Handle(UpdateCommentsCommand request, CancellationToken cancellationToken)
        {
            CommentsForUpdateValidator validator = new CommentsForUpdateValidator();
            FluentValidation.Results.ValidationResult results = await validator.ValidateAsync(request._commentsForUpdateDTO);

            if (results.Errors.Count > 0)
            {
                throw new ValidationException(results);
            }


            _sqlConnection.Open();

            var tran = _sqlConnection.BeginTransaction();

            try
            {
                var id = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
                request._commentsForUpdateDTO.LastEditedBy = Guid.Parse(id);

                var entity = await _CommentsRepository.Update(request._commentsForUpdateDTO, "dbo.usp_CommentsUpdate", _sqlConnection, tran);
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
