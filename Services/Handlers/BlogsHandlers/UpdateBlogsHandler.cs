using MediatR;
using Microsoft.AspNetCore.Http;
using Models.Exceptions;
using Models.Validators.ForUpdateValidator;
using Repositories.IRepositories;
using Services.Commands.BlogsCommands;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Handlers.BlogsHandlers
{
    public class UpdateBlogsHandler : IRequestHandler<UpdateBlogsCommand, bool>
    {
        private readonly IBlogsRepository _blogsRepository;
        private readonly SqlConnection _sqlConnection;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateBlogsHandler(IBlogsRepository blogsRepository, SqlConnection sqlConnection, IHttpContextAccessor httpContextAccessor)
        {
            _blogsRepository = blogsRepository;
            _sqlConnection = sqlConnection;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> Handle(UpdateBlogsCommand request, CancellationToken cancellationToken)
        {
            BlogsForUpdateValidator validator = new BlogsForUpdateValidator();
            FluentValidation.Results.ValidationResult results = await validator.ValidateAsync(request._blogsForUpdateDTO);

            if (results.Errors.Count > 0)
            {
                throw new ValidationException(results);
            }


            _sqlConnection.Open();

            var tran = _sqlConnection.BeginTransaction();

            try
            {
                var id = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
                request._blogsForUpdateDTO.LastEditedBy = Guid.Parse(id);
                var entity = await _blogsRepository.Update(request._blogsForUpdateDTO, "dbo.usp_BlogsUpdate", _sqlConnection, tran);
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