using DesafioUnidad1.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DesafioUnidad1.Respositories
{
    public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
         where TEntity : class, IBaseEntity
        where TContext : DesafioContext
    {
        private readonly DesafioContext _context;

        public async Task<TEntity> Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Get(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Entry(entity).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

    }
}
