using Models.DTOs.ForCreationDTO;
using Models.DTOs.ForDeleteDTO;
using Models.DTOs.ForUpdateDTO;
using Models.Models;
using Models.Params;
using Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class CommentsRepository : BaseRepository<Comments,CommentsParams,CommentsForCreationDTO,
        CommentsForUpdateDTO, Guid>, ICommentsRepository
    {
        public CommentsRepository(SqlConnection dbConnection) : base(dbConnection)
        {
        }
        public async override Task<Comments> GetById(Guid id, string storedProcedure)
        {
            return await base.GetById(id, storedProcedure);
        }
        public async override Task<List<Comments>> Get(CommentsParams param, string storedProcedure)
        {
            return await base.Get(param, storedProcedure);
        }
        public async override Task<Comments> Insert(CommentsForCreationDTO creationDTO, string storedProcedure, SqlConnection cnn, SqlTransaction tran)
        {
            return await base.Insert(creationDTO, storedProcedure, cnn, tran);
        }
        public async override Task<bool> Update(CommentsForUpdateDTO updateDTO, string storedProcedure, SqlConnection cnn, SqlTransaction tran)
        {
            return await base.Update(updateDTO, storedProcedure, cnn, tran);
        }
        public async override Task<bool> Delete(BaseDeleteDTO<Guid> baseDeleteDTO, string storedProcedure, SqlConnection cnn, SqlTransaction tran)
        {
            return await base.Delete(baseDeleteDTO, storedProcedure, cnn, tran);
        }
    }
}
