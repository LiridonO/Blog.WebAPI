using MediatR;
using Microsoft.AspNetCore.Http;
using Models.Exceptions;
using Models.Validators.ForUpdateValidator;
using Repositories.IRepositories;
using Services.Commands.TagsCommands;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Services.Handlers.TagsHandlers
{
    public class UpdateTagsHandler : IRequestHandler<UpdateTagsCommand, bool>
    {
        private readonly ITagsRepository _TagsRepository;
        private readonly SqlConnection _sqlConnection;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateTagsHandler(ITagsRepository TagsRepository, SqlConnection sqlConnection, IHttpContextAccessor httpContextAccessor)
        {
            _TagsRepository = TagsRepository;
            _sqlConnection = sqlConnection;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> Handle(UpdateTagsCommand request, CancellationToken cancellationToken)
        {
            TagsForUpdateValidator validator = new TagsForUpdateValidator();
            FluentValidation.Results.ValidationResult results = await validator.ValidateAsync(request._tagsForUpdateDTO);

            if (results.Errors.Count > 0)
            {
                throw new ValidationException(results);
            }


            _sqlConnection.Open();

            var tran = _sqlConnection.BeginTransaction();

            try
            {
                var id = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
                request._tagsForUpdateDTO.LastEditedBy = Guid.Parse(id);

                var entity = await _TagsRepository.Update(request._tagsForUpdateDTO, "dbo.usp_TagsUpdate", _sqlConnection, tran);
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
