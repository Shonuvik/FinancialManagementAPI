using FinancialManagement.Controllers.Dtos;

namespace FinancialManagement.Services.Interfaces
{
    public interface IFinancialManagementService
    {
        Task<List<ExpensesDto>> GetAll();

        Task<decimal> GetTotalExpensesValue();

        Task<ExpensesDto> Create(ExpensesDto productDto);
    }
}

