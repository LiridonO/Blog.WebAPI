using MediatR;
using Microsoft.AspNetCore.Http;
using Models.Exceptions;
using Models.Validators.ForUpdateValidator;
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
    public class UpdateBlogLikesHandler : IRequestHandler<UpdateBlogLikesCommand, bool>
    {
        private readonly IBlogLikesRepository _blogLikesRepository;
        private readonly SqlConnection _sqlConnection;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateBlogLikesHandler(IBlogLikesRepository blogLikesRepository, SqlConnection sqlConnection, IHttpContextAccessor httpContextAccessor)
        {
            _blogLikesRepository = blogLikesRepository;
            _sqlConnection = sqlConnection;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> Handle(UpdateBlogLikesCommand request, CancellationToken cancellationToken)
        {
            BlogLikesForUpdateValidator validator = new BlogLikesForUpdateValidator();
            FluentValidation.Results.ValidationResult results = await validator.ValidateAsync(request._blogLikesForUpdateDTO);

            if (results.Errors.Count > 0)
            {
                throw new ValidationException(results);
            }


            _sqlConnection.Open();

            var tran = _sqlConnection.BeginTransaction();

            try
            {
                var entity = await _blogLikesRepository.Update(request._blogLikesForUpdateDTO, "dbo.usp_BlogLikesUpdate", _sqlConnection, tran);
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