using MediatR;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Models.DTOs;
using Models.Models;
using Models.Validators.ForCreationValidator;
using Repositories.IRepositories;
using Services.Commands.CommentsCommands;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Services.Handlers.CommentsHandlers
{
    public class InsertCommentsHandler : IRequestHandler<InsertCommentsCommand, DefaultResponse<Comments>>
    {
        private readonly ICommentsRepository _repository;
        private readonly SqlConnection _cnn;
        private readonly IHttpContextAccessor _httpContext;

        public InsertCommentsHandler(ICommentsRepository repository, SqlConnection cnn, IHttpContextAccessor httpContext)
        {
            _repository = repository;
            _cnn = cnn;
            _httpContext = httpContext;
        }

        public async Task<DefaultResponse<Comments>> Handle(InsertCommentsCommand request, CancellationToken cancellationToken)
        {
            var id = _httpContext.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;

            CommentsForCreationValidator validator = new CommentsForCreationValidator();

            FluentValidation.Results.ValidationResult results = await validator.ValidateAsync(request._commentsForCreationDTO);

            if (results.Errors.Count > 0)
            {
                return new DefaultResponse<Comments>
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
                request._commentsForCreationDTO.InsertedBy = Guid.Parse(id);
                var entity = await _repository.Insert(request._commentsForCreationDTO, "dbo.usp_CommentsInsert", _cnn, tran);
                tran.Commit();

                return new DefaultResponse<Comments>
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
