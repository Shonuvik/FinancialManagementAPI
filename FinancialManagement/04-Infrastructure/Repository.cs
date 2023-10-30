using FinancialManagement.Domain.Entities;
using FinancialManagement.Infra.Context;
using FinancialManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinancialManagement.Repositories
{
    public class EFRepository<T> : IEFRepository<T> where T : Entity
	{
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public EFRepository(ApplicationDbContext dbContext)
		{
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
		}

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}

