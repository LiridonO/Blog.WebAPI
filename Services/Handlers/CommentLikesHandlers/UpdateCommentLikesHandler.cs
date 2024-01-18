using MediatR;
using Microsoft.AspNetCore.Http;
using Models.Exceptions;
using Models.Validators.ForUpdateValidator;
using Repositories.IRepositories;
using Services.Commands.CommentLikesCommands;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Handlers.CommentLikesHandlers
{
    public class UpdateCommentLikesHandler : IRequestHandler<UpdateCommentLikesCommand, bool>
    {
        private readonly ICommentLikesRepository _repository;
        private readonly SqlConnection _cnn;
        private readonly IHttpContextAccessor _httpContext;

        public UpdateCommentLikesHandler(ICommentLikesRepository repository, SqlConnection cnn, IHttpContextAccessor httpContext)
        {
            _repository = repository;
            _cnn = cnn;
            _httpContext = httpContext;
        }

        public async Task<bool> Handle(UpdateCommentLikesCommand request, CancellationToken cancellationToken)
        {
            CommentLikesForUpdateValidator validator = new CommentLikesForUpdateValidator();
            FluentValidation.Results.ValidationResult results = await validator.ValidateAsync(request._commentLikesForUpdateDTO);

            if (results.Errors.Count > 0)
            {
                throw new ValidationException(results);
            }

            _cnn.Open();
            var tran = _cnn.BeginTransaction();

            try
            {
                var entity = await _repository.Update(request._commentLikesForUpdateDTO, "dbo.usp_CommentLikesUpdate", _cnn, tran);
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
                _cnn.Close();
            }
        }
    }
}
