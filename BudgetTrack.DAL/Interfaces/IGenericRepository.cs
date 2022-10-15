using System.Linq.Expressions;

namespace BudgetTrack.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class, new()
    {
        Task<T> Add(T entity);
        Task<List<T>> AddRange(List<T> entity);
        Task<T> Update(T entity);
        Task<List<T>> UpdateRange(List<T> entity);
        Task<int> Delete(T entity);
        Task<List<T>> GetList(Expression<Func<T, bool>> filter);
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
    }
}
