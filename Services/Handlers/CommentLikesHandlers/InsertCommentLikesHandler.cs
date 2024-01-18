using MediatR;
using Microsoft.AspNetCore.Http;
using Models.DTOs.ForCreationDTO;
using Models.Exceptions;
using Models.Validators.ForCreationValidator;
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
    public class InsertCommentLikesHandler : IRequestHandler<InsertCommentLikesCommand, CommentLikesForCreationDTO>
    {
        private readonly ICommentLikesRepository _repository;
        private readonly SqlConnection _cnn;
        private readonly IHttpContextAccessor _httpContext;

        public InsertCommentLikesHandler(ICommentLikesRepository repository, SqlConnection cnn, IHttpContextAccessor httpContext)
        {
            _repository = repository;
            _cnn = cnn;
            _httpContext = httpContext;
        }

        public async Task<CommentLikesForCreationDTO> Handle(InsertCommentLikesCommand request, CancellationToken cancellationToken)
        {
            CommentLikesForCreationValidator validator = new CommentLikesForCreationValidator();
            FluentValidation.Results.ValidationResult results = await validator.ValidateAsync(request._commentLikesForCreationDTO);

            if (results.Errors.Count > 0)
            {
                throw new ValidationException(results);
            }

            _cnn.Open();

            var tran = _cnn.BeginTransaction();

            try
            {
                var newId = Guid.NewGuid();
                request._commentLikesForCreationDTO.Id = newId;
                var entity = await _repository.Insert(request._commentLikesForCreationDTO, "dbo.usp_CommentLikesInsert", _cnn, tran);
                tran.Commit();
                return new CommentLikesForCreationDTO();
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
