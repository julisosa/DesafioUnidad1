using DesafiosAPI.Interfaces;
using DesafiosAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafiosAPI.Repositories
{
    public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
         where TEntity : class, IBaseEntity
        where TContext : DesafiosContext
    {
        private readonly TContext _context;

        public BaseRepository(TContext context)
        {
            _context = context;
        }

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

        Task<TEntity> IBaseRepository<TEntity>.Add(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        Task<TEntity> IBaseRepository<TEntity>.Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<TEntity> IBaseRepository<TEntity>.Get(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<List<TEntity>> IBaseRepository<TEntity>.GetAll()
        {
            throw new System.NotImplementedException();
        }

        Task<TEntity> IBaseRepository<TEntity>.Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
