using Npgsql;
using System.Data;

namespace MosquitoLaboratorio.DbContext
{
    public class DBContext : IDisposable
    {
        private readonly string _connectionString;
        private IDbConnection? _connection;

        public DBContext(string connectionString) => _connectionString = connectionString;

        public IDbConnection GetConnection()
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new NpgsqlConnection(_connectionString);
                _connection.Open();
            }
            return _connection;
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }
}
