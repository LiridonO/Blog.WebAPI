using MediatR;
using Microsoft.AspNetCore.Http;
using Models.DTOs.ForDeleteDTO;
using Models.Exceptions;
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
    public class DeleteCommentLikesHandler : IRequestHandler<DeleteCommentLikesCommand, bool>
    {
        private readonly ICommentLikesRepository _repository;
        private readonly SqlConnection _cnn;
        private readonly IHttpContextAccessor _httpContext;

        public DeleteCommentLikesHandler(ICommentLikesRepository repository, SqlConnection cnn, IHttpContextAccessor httpContext)
        {
            _repository = repository;
            _cnn = cnn;
            _httpContext = httpContext;
        }

        public async Task<bool> Handle(DeleteCommentLikesCommand request, CancellationToken cancellationToken)
        {
            var exists = await _repository.GetById(request._id, "dbo.usp_CommentLikesSelect");

            if (exists == null)
                throw new NotFoundException("Comment like does not exists!");

            _cnn.Open();
            var tran = _cnn.BeginTransaction();

            try
            {
                var deleted = await _repository.Delete(new BaseDeleteDTO<Guid>
                {
                    Id = request._id,
                    DeletedBy = Guid.NewGuid()
                }, "dbo.usp_CommentLikesDelete", _cnn, tran);
                tran.Commit();
                return deleted;
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
