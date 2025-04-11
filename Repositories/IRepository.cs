using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaIndicadoresAPI.Repositories{
    public interface IRepository<T, TKey> where T : class
    {
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(TKey id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(TKey id);
    Task<bool> ExistsAsync(TKey id);
    }

}
