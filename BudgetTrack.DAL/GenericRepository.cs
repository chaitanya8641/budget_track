using BudgetTrack.DAL.Interfaces;
using BudgetTrack.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BudgetTrack.DAL
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        private readonly BudgetContext _budgetDbContext;

        protected GenericRepository(BudgetContext budgetDbContext)
        {
            _budgetDbContext = budgetDbContext;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await _budgetDbContext.AddAsync(entity);
            await _budgetDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> AddRange(List<TEntity> entity)
        {
            await _budgetDbContext.AddRangeAsync(entity);
            await _budgetDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _budgetDbContext.Set<TEntity>().Update(entity);
            await _budgetDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> UpdateRange(List<TEntity> entity)
        {
            _budgetDbContext.Set<TEntity>().UpdateRange(entity);
            await _budgetDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Delete(TEntity entity)
        {
            _budgetDbContext.Remove(entity);
            return await _budgetDbContext.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter)
        {
            return await (filter == null ? _budgetDbContext.Set<TEntity>().ToListAsync() : _budgetDbContext.Set<TEntity>().Where(filter).ToListAsync());
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            var result = await _budgetDbContext.Set<TEntity>().FirstOrDefaultAsync(filter);
            if (result == null)
                return new TEntity();

            return result;
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> expression)
        {
            return await _budgetDbContext.Set<TEntity>().Where(expression).ToListAsync();
        }
    }
}
