using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MovimentosManuais.Libraries
{
    public interface IConnectionContext : IDisposable
    {
        ConnectionState ConnectionState { get; }

        T ExecuteScalar<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<T> ExecuteScalarAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        int Execute(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        Task BulkCopy(DataTable dataTable, string destinationTableName, int timeout = 30);

        // CRUD methods
        bool Delete<T>(T entityToDelete, IDbTransaction transaction = null, int? commandTimeout = null) where T : class;
        bool DeleteAll<T>(IDbTransaction transaction = null, int? commandTimeout = null) where T : class;
        Task<bool> DeleteAllAsync<T>(IDbTransaction transaction = null, int? commandTimeout = null) where T : class;
        Task<bool> DeleteAsync<T>(T entityToDelete, IDbTransaction transaction = null, int? commandTimeout = null) where T : class;
        T Get<T>(object id, IDbTransaction transaction = null, int? commandTimeout = null) where T : class;
        IEnumerable<T> GetAll<T>(IDbTransaction transaction = null, int? commandTimeout = null) where T : class;
        Task<IEnumerable<T>> GetAllAsync<T>(IDbTransaction transaction = null, int? commandTimeout = null) where T : class;
        Task<T> GetAsync<T>(object id, IDbTransaction transaction = null, int? commandTimeout = null) where T : class;
        long Insert<T>(T entityToInsert, IDbTransaction transaction = null, int? commandTimeout = null) where T : class;
        Task<int> InsertAsync<T>(T entityToInsert, IDbTransaction transaction = null, int? commandTimeout = null, ISqlAdapter sqlAdapter = null) where T : class;
        bool Update<T>(T entityToUpdate, IDbTransaction transaction = null, int? commandTimeout = null) where T : class;
        Task<bool> UpdateAsync<T>(T entityToUpdate, IDbTransaction transaction = null, int? commandTimeout = null) where T : class;
    }
}