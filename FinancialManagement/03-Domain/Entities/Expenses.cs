using FinancialManagement.Infrastructure.Interfaces;

namespace FinancialManagement.Domain.Entities
{
    public class Expenses : Entity
    {
        private readonly IExpensesRepository _expensesRepository;

        public Expenses() { }

        public Expenses(string name, string type, decimal value)
        {
            Validate(name, type, value);

            Name = name;
            Type = type;
            Value = value;
        }

        public string Name { get; private set; }

        public string Type { get; private set; }

        public decimal Value { get; private set; }

        public async Task Add(Expenses expenses)
        {
            await _expensesRepository.Add(expenses);
        }

        public async Task<List<Expenses>> GetAll()
        {
            return await _expensesRepository.GetAll();
        }

        public async Task<decimal> Sum()
        {
            var expensesList = await _expensesRepository.GetAll();

            return expensesList.Sum(x => x.Value);
        }

        private void Validate(string name, string type, decimal value)
        {
            if (string.IsNullOrEmpty(name))
                throw new ExceptionBusiness("Nome do produto deve ser fornecido.");

            if (string.IsNullOrEmpty(type))
                throw new ExceptionBusiness("O tipo do produto deve ser fornecido.");

            if (value < 0)
                throw new ExceptionBusiness("O valor do produto não pode ser menor do que zero.");
        }
    }
}