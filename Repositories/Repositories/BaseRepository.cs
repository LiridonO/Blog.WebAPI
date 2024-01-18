using Dapper;
using Models.Models;
using Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DTOs.ForDeleteDTO;

namespace Repositories.Repositories
{
    public class BaseRepository<T, U, X, Y, TKey> : IBaseRepository<T, U, X, Y, TKey> where T : class
    {
        private readonly SqlConnection _dbConnection;

        public BaseRepository(SqlConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async virtual Task<bool> Delete(BaseDeleteDTO<TKey> baseDeleteDTO, string storedProcedure, SqlConnection cnn, SqlTransaction tran)
        {
            await cnn.ExecuteAsync(storedProcedure, baseDeleteDTO, tran, commandType: CommandType.StoredProcedure);
            return true;
        }

        public async virtual Task<List<T>> Get(U param, string storedProcedure)
        {
            IEnumerable<T> output = await _dbConnection.QueryAsync<T>(storedProcedure, param, commandType: CommandType.StoredProcedure);
            return output.ToList();
        }

        public async virtual Task<T> GetById(Guid id, string storedProcedure)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id);
            T output = await _dbConnection.QueryFirstOrDefaultAsync<T>(storedProcedure, p, commandType: CommandType.StoredProcedure);
            return output;
        }

        public async Task<PagedList<T>> GetPagedList(U param, string storedProcedure)
        {
            IEnumerable<T> output = await _dbConnection.QueryAsync<T>(storedProcedure, param, commandTimeout: 5000, commandType: CommandType.StoredProcedure);

            return PagedList<T>.Create(output, ((dynamic)param).PageNumber, ((dynamic)param).PageSize);
        }

        public async virtual Task<T> Insert(X creationDTO, string storedProcedure, SqlConnection cnn, SqlTransaction tran)
        {
            var insertedElement = await _dbConnection.QueryFirstOrDefaultAsync<T>(storedProcedure, creationDTO, tran, commandType: CommandType.StoredProcedure);

            return insertedElement;
        }

        public async virtual Task<bool> Update(Y updateDTO, string storedProcedure, SqlConnection cnn, SqlTransaction tran)
        {
            await _dbConnection.ExecuteAsync(storedProcedure, updateDTO, tran, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}