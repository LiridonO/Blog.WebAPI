using MediatR;
using Microsoft.AspNetCore.Http;
using Models.DTOs.ForDeleteDTO;
using Models.Exceptions;
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
    public class DeleteBlogLikesHandler : IRequestHandler<DeleteBlogLikesCommand, bool>
    {
        private readonly IBlogLikesRepository _repository;
        private readonly SqlConnection _cnn;
        private readonly IHttpContextAccessor _httpContext;

        public DeleteBlogLikesHandler(IBlogLikesRepository repository, SqlConnection cnn, IHttpContextAccessor httpContext)
        {
            _repository = repository;
            _cnn = cnn;
            _httpContext = httpContext;
        }

        public async Task<bool> Handle(DeleteBlogLikesCommand request, CancellationToken cancellationToken)
        {
            var exists = await _repository.GetById(request._id, "dbo.usp_BlogLikesSelect");

            if (exists == null)
                throw new NotFoundException("Blog Likes does not exists!");

            _cnn.Open();
            var tran = _cnn.BeginTransaction();

            try
            {
                var deleted = await _repository.Delete(new BaseDeleteDTO<Guid>
                {
                    Id =request._id,
                    DeletedBy =Guid.NewGuid()
                }, "dbo.usp_BlogLikesDelete", _cnn, tran);
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
