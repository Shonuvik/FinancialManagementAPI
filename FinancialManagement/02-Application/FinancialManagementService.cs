using FinancialManagement.Controllers.Dtos;
using FinancialManagement.Domain.Entities;
using FinancialManagement.Services.Interfaces;

namespace FinancialManagement.Services
{
    public class FinancialManagementService : IFinancialManagementService
    {
        public async Task<List<ExpensesDto>> GetAll()
        {
            var expenses = new Expenses();

            var getAllExpenses = await expenses.GetAll();
            return Map(getAllExpenses);
        }

        public async Task<ExpensesDto> Create(ExpensesDto expensesDto)
        {
            var expenses = ParseToEntity(expensesDto);

            await expenses.Add(expenses);

            return expensesDto;
        }

        public async Task<decimal> GetTotalExpensesValue()
        {
            var expenses = new Expenses();

            return await expenses.Sum();
        }

        private Expenses ParseToEntity(ExpensesDto expensesDto)
        {
            Expenses expenses = new(expensesDto.Name, expensesDto.Type, expensesDto.Value);
            return expenses;
        }

        private List<ExpensesDto> Map(List<Expenses> getAllExpenses)
        {
            var expenses = new List<ExpensesDto>();
            foreach (var item in getAllExpenses)
            {
                expenses.Add(
                    new ExpensesDto
                    {
                        Name = item.Name,
                        Type = item.Type,
                        Value = item.Value
                    });
            }

            return expenses;
        }
    }
}