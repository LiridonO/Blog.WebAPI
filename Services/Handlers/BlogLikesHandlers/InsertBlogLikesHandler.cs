using MediatR;
using Microsoft.AspNetCore.Http;
using Models.DTOs.ForCreationDTO;
using Models.Exceptions;
using Models.Validators.ForCreationValidator;
using Repositories.IRepositories;
using Services.Commands.BlogLikesCommands;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Handlers.BlogLikesHandlers
{
    public class InsertBlogLikesHandler : IRequestHandler<InsertBlogLikesCommand, BlogLikesForCreationDTO>
    {
        private readonly IBlogLikesRepository _repository;
        private readonly IHttpContextAccessor _httpContext;
        private readonly SqlConnection _cnn;

        public InsertBlogLikesHandler(IBlogLikesRepository repository, IHttpContextAccessor httpContext, SqlConnection cnn)
        {
            _repository = repository;
            _httpContext = httpContext;
            _cnn = cnn;
        }

        public async Task<BlogLikesForCreationDTO> Handle(InsertBlogLikesCommand request, CancellationToken cancellationToken)
        {
            BlogLikesForCreationValidator validator = new BlogLikesForCreationValidator();
            FluentValidation.Results.ValidationResult results = await validator.ValidateAsync(request._blogLikesForCreationDTO);

            if (results.Errors.Count > 0)
            {
                throw new ValidationException(results);
            }

            _cnn.Open();

            var tran = _cnn.BeginTransaction();

            try
            {
                var newId = Guid.NewGuid();
                request._blogLikesForCreationDTO.Id = newId;
                var entity = await _repository.Insert(request._blogLikesForCreationDTO, "dbo.usp_BlogLikesInsert", _cnn, tran);
                tran.Commit();
                return new BlogLikesForCreationDTO();
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
