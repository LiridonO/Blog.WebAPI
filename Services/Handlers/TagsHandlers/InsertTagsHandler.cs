using MediatR;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Models.DTOs;
using Models.DTOs.ForCreationDTO;
using Models.Exceptions;
using Models.Models;
using Models.Validators.ForCreationValidator;
using Repositories.IRepositories;
using Services.Commands.TagsCommands;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Services.Handlers.TagsHandlers
{
    public class InsertTagsHandler : IRequestHandler<InsertTagsCommand, DefaultResponse<Tags>>
    {
        private readonly ITagsRepository _repository;
        private readonly SqlConnection _cnn;
        private readonly IHttpContextAccessor _httpContext;

        public InsertTagsHandler(ITagsRepository repository, SqlConnection cnn, IHttpContextAccessor httpContext)
        {
            _repository = repository;
            _cnn = cnn;
            _httpContext = httpContext;
        }

        public async Task<DefaultResponse<Tags>> Handle(InsertTagsCommand request, CancellationToken cancellationToken)
        {
            var id = _httpContext.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;

            TagsForCreationValidator validator = new TagsForCreationValidator();

            FluentValidation.Results.ValidationResult results = await validator.ValidateAsync(request._tagsForCreationDTO);

            if (results.Errors.Count > 0)
            {
                return new DefaultResponse<Tags>
                {
                    Success = false,
                    Message = "Data in wrong format",
                    Errors = results.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            _cnn.Open();
            var tran = _cnn.BeginTransaction();

            try
            {
                request._tagsForCreationDTO.InsertedBy = Guid.Parse(id);
                var entity = await _repository.Insert(request._tagsForCreationDTO, "dbo.usp_TagsInsert", _cnn, tran);
                tran.Commit();

                return new DefaultResponse<Tags>
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
