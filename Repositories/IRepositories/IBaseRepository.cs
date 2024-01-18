using Models.DTOs.ForDeleteDTO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface IBaseRepository<T, U, X, Y, TKey> where T : class
    {
        Task<List<T>> Get(U param, string storedProcedure);
        Task<T> GetById(Guid id, string storedProcedure);
        Task<T> Insert(X creationDTO, string storedProcedure, SqlConnection cnn, SqlTransaction tran);
        Task<bool> Update(Y updateDTO, string storedProcedure, SqlConnection cnn, SqlTransaction tran);
        Task<bool> Delete(BaseDeleteDTO<TKey> baseDeleteDTO, string storedProcedure, SqlConnection cnn, SqlTransaction tran);
        Task<PagedList<T>> GetPagedList(U param, string storedProcedure);
    }
}
