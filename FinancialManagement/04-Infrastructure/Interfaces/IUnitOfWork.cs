using System.Data;

namespace FinancialManagement.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
	{
		public IDbConnection Connection { get; }
	}
}