using FinancialManagement.Domain.Entities;
using FinancialManagement.Infrastructure.Interfaces;
using FinancialManagement.Repositories.Interfaces;

namespace FinancialManagement.Infrastructure
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly IEFRepository<Expenses> _repository;

        public ExpensesRepository(IEFRepository<Expenses> repository)
        {
            _repository = repository;
        }

        public async Task<List<Expenses>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task Add(Expenses expenses)
        {
            await _repository.Create(expenses);
        }
    }
}

