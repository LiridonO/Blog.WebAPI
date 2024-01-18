using MediatR;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Models.DTOs;
using Models.DTOs.ForCreationDTO;
using Models.Exceptions;
using Models.Models;
using Models.Validators.ForCreationValidator;
using Repositories.IRepositories;
using Services.Commands.BlogsCommands;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Services.Handlers.BlogsHandlers
{
    public class InsertBlogsHandler : IRequestHandler<InsertBlogsCommand, DefaultResponse<Blogs>>
    {
        private readonly IBlogsRepository _repository;
        private readonly SqlConnection _cnn;
        private readonly IHttpContextAccessor _httpContext;

        public InsertBlogsHandler(IBlogsRepository repository, SqlConnection cnn, IHttpContextAccessor httpContext)
        {
            _repository = repository;
            _cnn = cnn;
            _httpContext = httpContext;
        }

        public async Task<DefaultResponse<Blogs>> Handle(InsertBlogsCommand request, CancellationToken cancellationToken)
        {
            var id = _httpContext.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;

            BlogsForCreationValidator validator = new BlogsForCreationValidator();

            FluentValidation.Results.ValidationResult results = await validator.ValidateAsync(request._blogsForCreationDTO);

            if (results.Errors.Count > 0)
            {
                return new DefaultResponse<Blogs>
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
                request._blogsForCreationDTO.InsertedBy = Guid.Parse(id);
                var entity = await _repository.Insert(request._blogsForCreationDTO, "dbo.usp_BlogsInsert", _cnn, tran);
                tran.Commit();

                return new DefaultResponse<Blogs>
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
