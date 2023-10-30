using FinancialManagement.Domain.Entities;

namespace FinancialManagement.Domains.Entities
{
    public class ExpensesEntity : Entity
    {
        public string ExpensesName { get; set; }

        public string CategoryName { get; set; }
    }
}

