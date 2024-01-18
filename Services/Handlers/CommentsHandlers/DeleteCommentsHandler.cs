using MediatR;
using Microsoft.AspNetCore.Http;
using Models.DTOs;
using Models.DTOs.ForDeleteDTO;
using Models.Exceptions;
using Repositories.IRepositories;
using Services.Commands.CommentsCommands;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Handlers.CommentsHandlers
{
    public class DeleteCommentsHandler : IRequestHandler<DeleteCommentsCommand, DefaultResponse<bool>>
    {
        private readonly ICommentsRepository _repository;
        private readonly SqlConnection _cnn;
        private readonly IHttpContextAccessor _httpContext;

        public DeleteCommentsHandler(ICommentsRepository repository, SqlConnection cnn, IHttpContextAccessor httpContext)
        {
            _repository = repository;
            _cnn = cnn;
            _httpContext = httpContext;
        }

        public async Task<DefaultResponse<bool>> Handle(DeleteCommentsCommand request, CancellationToken cancellationToken)
        {
            var exists = await _repository.GetById(request._id, "dbo.usp_CommentsSelect");

            if (exists == null)
            {
                return new DefaultResponse<bool>
                {
                    Message = "Comment not found",
                    Success = false,
                    Data = false
                };
            }


            _cnn.Open();
            var tran = _cnn.BeginTransaction();

            try
            {
                var id = _httpContext.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
                var deleted = await _repository.Delete(new BaseDeleteDTO<Guid>
                {
                    Id = request._id,
                    DeletedBy = Guid.Parse(id)
                }, "dbo.usp_CommentsDelete", _cnn, tran);
                tran.Commit();

                return new DefaultResponse<bool>
                {
                    Success = true,
                    Message = "Deleted with success",
                    Data = deleted
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
