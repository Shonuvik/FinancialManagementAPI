using System.Data;
using FinancialManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;

namespace FinancialManagement.Infra.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;
        private bool _disposed;

        public UnitOfWork(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(_configuration["ConnectionString"]);
            _connection.Open();
        }

        public IDbConnection Connection => _connection;

        public void Dispose()
        {
            if (!_disposed)
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();

                _connection?.Dispose();
                _disposed = true;
            }
        }
    }
}