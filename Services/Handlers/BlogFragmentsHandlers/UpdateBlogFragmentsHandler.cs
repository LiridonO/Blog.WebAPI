using MediatR;
using Microsoft.AspNetCore.Http;
using Models.Exceptions;
using Models.Validators.ForUpdateValidator;
using Repositories.IRepositories;
using Services.Commands.BlogFragmentsCommands;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Services.Handlers.BlogFragmentsHandlers
{
    public class UpdateBlogFragmentsHandler : IRequestHandler<UpdateBlogFragmentsCommand, bool>
    {
        private readonly IBlogFragmentsRepository _blogFragmentsRepository;
        private readonly SqlConnection _sqlConnection;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateBlogFragmentsHandler(IBlogFragmentsRepository blogFragmentsRepository, SqlConnection sqlConnection, IHttpContextAccessor httpContextAccessor)
        {
            _blogFragmentsRepository = blogFragmentsRepository;
            _sqlConnection = sqlConnection;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> Handle(UpdateBlogFragmentsCommand request, CancellationToken cancellationToken)
        {
            BlogFragmentsForUpdateValidator validator = new BlogFragmentsForUpdateValidator();
            FluentValidation.Results.ValidationResult results = await validator.ValidateAsync(request._blogFragmentsForUpdateDTO);

            if (results.Errors.Count > 0)
            {
                throw new ValidationException(results);
            }


            _sqlConnection.Open();

            var tran = _sqlConnection.BeginTransaction();

            try
            {
                var id = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
                request._blogFragmentsForUpdateDTO.LastEditedBy = Guid.Parse(id);

                var entity = await _blogFragmentsRepository.Update(request._blogFragmentsForUpdateDTO, "dbo.usp_BlogFragmentsUpdate", _sqlConnection, tran);
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
