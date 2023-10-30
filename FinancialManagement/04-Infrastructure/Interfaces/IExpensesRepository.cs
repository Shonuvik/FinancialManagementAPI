using FinancialManagement.Domain.Entities;

namespace FinancialManagement.Infrastructure.Interfaces
{
    public interface IExpensesRepository
	{
        Task<List<Expenses>> GetAll();

        Task Add(Expenses expenses);

    }
}

