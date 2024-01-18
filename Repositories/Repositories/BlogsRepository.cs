﻿using Models.DTOs.ForCreationDTO;
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
    public class BlogsRepository : BaseRepository<Blogs, BlogsParams, BlogsForCreationDTO,
        BlogsForUpdateDTO, Guid>, IBlogsRepository
    {
        public BlogsRepository(SqlConnection dbConnection) : base(dbConnection)
        {
        }
        public async override Task<Blogs> GetById(Guid id, string storedProcedure)
        {
            return await base.GetById(id, storedProcedure);
        }
        public async override Task<List<Blogs>> Get(BlogsParams param, string storedProcedure)
        {
            return await base.Get(param, storedProcedure);
        }
        public async override Task<Blogs> Insert(BlogsForCreationDTO creationDTO, string storedProcedure, SqlConnection cnn, SqlTransaction tran)
        {
            return await base.Insert(creationDTO, storedProcedure, cnn, tran);
        }
        public async override Task<bool> Update(BlogsForUpdateDTO updateDTO, string storedProcedure, SqlConnection cnn, SqlTransaction tran)
        {
            return await base.Update(updateDTO, storedProcedure, cnn, tran);
        }
        public async override Task<bool> Delete(BaseDeleteDTO<Guid> baseDeleteDTO, string storedProcedure, SqlConnection cnn, SqlTransaction tran)
        {
            return await base.Delete(baseDeleteDTO, storedProcedure, cnn, tran);
        }
    }
}
