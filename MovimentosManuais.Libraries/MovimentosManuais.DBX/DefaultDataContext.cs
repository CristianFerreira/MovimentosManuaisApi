using System;
using System.Data.SqlClient;

namespace MovimentosManuais.Libraries
{
    internal class DefaultDataContext : IDataContext
    {
        public string ConnectionString { get; private set; }

        internal DefaultDataContext(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            ConnectionString = connectionString;
        }

        public IConnectionContext AcquireConnection()
        {
            return new DefaultConnectionContext(new SqlConnection(ConnectionString));
        }
    }
}