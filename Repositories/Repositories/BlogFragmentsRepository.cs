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
    public class BlogFragmentsRepository : BaseRepository<BlogFragments,BlogFragmentsParams,BlogFragmentsForCreationDTO,
        BlogFragmentsForUpdateDTO, Guid>, IBlogFragmentsRepository
    {
        public BlogFragmentsRepository(SqlConnection dbConnection) : base(dbConnection)
        {
        }
        public async override Task<BlogFragments> GetById(Guid id, string storedProcedure)
        {
            return await base.GetById(id, storedProcedure);
        }
        public async override Task<List<BlogFragments>> Get(BlogFragmentsParams param, string storedProcedure)
        {
            return await base.Get(param, storedProcedure);
        }
        public async override Task<BlogFragments> Insert(BlogFragmentsForCreationDTO creationDTO, string storedProcedure, SqlConnection cnn, SqlTransaction tran)
        {
            return await base.Insert(creationDTO, storedProcedure, cnn, tran);
        }
        public async override Task<bool> Update(BlogFragmentsForUpdateDTO updateDTO, string storedProcedure, SqlConnection cnn, SqlTransaction tran)
        {
            return await base.Update(updateDTO, storedProcedure, cnn, tran);
        }
        public async override Task<bool> Delete(BaseDeleteDTO<Guid> baseDeleteDTO, string storedProcedure, SqlConnection cnn, SqlTransaction tran)
        {
            return await base.Delete(baseDeleteDTO, storedProcedure, cnn, tran);
        }
    }
}
