using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace AppDapper.Data
{
    public interface IDapper : IDisposable
    {
        DbConnection GetConnection();
        Task<IEnumerable<T>> GetAll<T>(string query, DynamicParameters pars, CommandType commandType = CommandType.StoredProcedure);
        Task<T> Get<T>(string query, DynamicParameters pars, CommandType commandType = CommandType.StoredProcedure);
        Task<T> Update<T>(string query, DynamicParameters pars, CommandType commandType = CommandType.StoredProcedure);
        Task<T> Delete<T>(string query, DynamicParameters pars, CommandType commandType = CommandType.StoredProcedure);
        Task<T> Create<T>(string query, DynamicParameters pars, CommandType commandType = CommandType.StoredProcedure);
    }
}
