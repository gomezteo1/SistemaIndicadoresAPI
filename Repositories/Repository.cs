using Microsoft.EntityFrameworkCore;
using SistemaIndicadoresAPI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaIndicadoresAPI.Repositories
{
    public class Repository<T, TKey> : IRepository<T, TKey> where T : class
    {
        private readonly SistemaIndicadoresContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(SistemaIndicadoresContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T?> GetByIdAsync(TKey id) => await _dbSet.FindAsync(id);

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity != null;
        }
    }
}
