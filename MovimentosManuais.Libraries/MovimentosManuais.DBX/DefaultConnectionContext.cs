using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MovimentosManuais.Libraries
{
    internal class DefaultConnectionContext : IConnectionContext
    {
        private const int DefaultBulkCopyTimeout = 30; // in seconds

        private readonly IDbConnection connection;

        private bool disposed = false;

        public ConnectionState ConnectionState { get { return connection.State; } }

        internal DefaultConnectionContext(IDbConnection connection)
        {
            this.connection = connection;
        }

        private void OpenConnection(IDbConnection connection)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (disposed)
            {
                throw new ObjectDisposedException(typeof(DefaultConnectionContext).Name);
            }
            OpenConnection(connection);
            return connection.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);
        }

        public int Execute(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (disposed)
            {
                throw new ObjectDisposedException(typeof(DefaultConnectionContext).Name);
            }
            OpenConnection(connection);
            return connection.Execute(sql, param, transaction, commandTimeout, commandType);
        }

        public T ExecuteScalar<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (disposed)
            {
                throw new ObjectDisposedException(typeof(DefaultConnectionContext).Name);
            }
            OpenConnection(connection);
            return connection.ExecuteScalar<T>(sql, param, transaction, commandTimeout, commandType);
        }

        public Task<T> ExecuteScalarAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (disposed)
            {
                throw new ObjectDisposedException(typeof(DefaultConnectionContext).Name);
            }
            OpenConnection(connection);
            return connection.ExecuteScalarAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }

        public async Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (disposed)
            {
                throw new ObjectDisposedException(typeof(DefaultConnectionContext).Name);
            }
            OpenConnection(connection);
            return await connection.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (disposed)
            {
                throw new ObjectDisposedException(typeof(DefaultConnectionContext).Name);
            }
            OpenConnection(connection);
            return await connection.QueryAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }

        public bool Delete<T>(T entityToDelete, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            if (disposed)
            {
                throw new ObjectDisposedException(typeof(DefaultConnectionContext).Name);
            }
            OpenConnection(connection);
            return connection.Delete(entityToDelete, transaction, commandTimeout);
        }

        public bool DeleteAll<T>(IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            if (disposed)
            {
                throw new ObjectDisposedException(typeof(DefaultConnectionContext).Name);
            }
            OpenConnection(connection);
            return connection.DeleteAll<T>(transaction, commandTimeout);
        }

        public async Task<bool> DeleteAllAsync<T>(IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            if (disposed)
            {
                throw new ObjectDisposedException(typeof(DefaultConnectionContext).Name);
            }
            OpenConnection(connection);
            return await connection.DeleteAllAsync<T>(transaction, commandTimeout);
        }

        public async Task<bool> DeleteAsync<T>(T entityToDelete, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            if (disposed)
            {
                throw new ObjectDisposedException(typeof(DefaultConnectionContext).Name);
            }
            OpenConnection(connection);
            return await connection.DeleteAsync<T>(entityToDelete, transaction, commandTimeout);
        }

        public T Get<T>(object id, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            if (disposed)
            {
                throw new ObjectDisposedException(typeof(DefaultConnectionContext).Name);
            }
            OpenConnection(connection);
            return connection.Get<T>(id, transaction, commandTimeout);
        }

        public IEnumerable<T> GetAll<T>(IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            if (disposed)
            {
                throw new ObjectDisposedException(typeof(DefaultConnectionContext).Name);
            }
            OpenConnection(connection);
            return connection.GetAll<T>(transaction, commandTimeout);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            if (disposed)
            {
                throw new ObjectDisposedException(typeof(DefaultConnectionContext).Name);
            }
            OpenConnection(connection);
            return await connection.GetAllAsync<T>(transaction, commandTimeout);
        }

        public async Task<T> GetAsync<T>(object id, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            if (disposed)
            {
                throw new ObjectDisposedException(typeof(DefaultConnectionContext).Name);
            }
            OpenConnection(connection);
            return await connection.GetAsync<T>(id, transaction, commandTimeout);
        }

        public long Insert<T>(T entityToInsert, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            if (disposed)
            {
                throw new ObjectDisposedException(typeof(DefaultConnectionContext).Name);
            }
            OpenConnection(connection);
            return connection.Insert<T>(entityToInsert, transaction, commandTimeout);
        }

        public async Task<int> InsertAsync<T>(T entityToInsert, IDbTransaction transaction = null, int? commandTimeout = null, ISqlAdapter sqlAdapter = null) where T : class
        {
            if (disposed)
            {
                throw new ObjectDisposedException(typeof(DefaultConnectionContext).Name);
            }
            OpenConnection(connection);
            return await connection.InsertAsync<T>(entityToInsert, transaction, commandTimeout);
        }

        public bool Update<T>(T entityToUpdate, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            if (disposed)
            {
                throw new ObjectDisposedException(typeof(DefaultConnectionContext).Name);
            }
            OpenConnection(connection);
            return connection.Update<T>(entityToUpdate, transaction, commandTimeout);
        }

        public async Task<bool> UpdateAsync<T>(T entityToUpdate, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            if (disposed)
            {
                throw new ObjectDisposedException(typeof(DefaultConnectionContext).Name);
            }
            OpenConnection(connection);
            return await connection.UpdateAsync<T>(entityToUpdate, transaction, commandTimeout);
        }

        public async Task BulkCopy(DataTable dataTable, string destinationTableName, int timeout = DefaultBulkCopyTimeout)
        {
            if (disposed)
            {
                throw new ObjectDisposedException(typeof(DefaultConnectionContext).Name);
            }
            OpenConnection(connection);
            using (var sqlBulkCopy = new SqlBulkCopy((SqlConnection)connection))
            {
                if (timeout < 0)
                {
                    timeout = 30;
                }
                sqlBulkCopy.BulkCopyTimeout = timeout;
                sqlBulkCopy.DestinationTableName = destinationTableName;
                await sqlBulkCopy.WriteToServerAsync(dataTable);
            }
        }

        public void Dispose()
        {
            disposed = true;
            connection.Close();
            connection.Dispose();
        }
    }
}