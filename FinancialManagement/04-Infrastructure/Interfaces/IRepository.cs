namespace FinancialManagement.Repositories.Interfaces
{
    public interface IEFRepository<T>
    {
        Task<List<T>> GetAll();

        Task Create(T entity);

        Task Update(T entity);

        Task Delete(T enitity);
    }
}

