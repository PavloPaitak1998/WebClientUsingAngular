using DataAccessLayer.Data;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementation.Repositories
{
    public class Repository<TEntity>:IRepository<TEntity> where TEntity:class
    {
        protected readonly DispatcherContext Context;

        private DbSet<TEntity> entities;

        public Repository(DispatcherContext context)
        {
            Context = context;
            entities = Context.Set<TEntity>();
        }

        public async virtual Task<TEntity> GetAsync(int id)
        {
            return await entities.FindAsync(id);
        }

        public async virtual Task<List<TEntity>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }

        public async virtual Task AddAsync(TEntity entity)
        {
            await entities.AddAsync(entity);
            await SaveChangesAsync().ConfigureAwait(false);
        }

        public async virtual Task AddRangeAsync(List<TEntity> _entities)
        {
            await entities.AddRangeAsync(_entities);
            await Context.SaveChangesAsync();
        }

        public async virtual Task UpdateAsync(TEntity entity)
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }

        public async virtual Task DeleteAsync(TEntity entity)
        {
            entities.Remove(entity);
            await SaveChangesAsync().ConfigureAwait(false);
        }

        public async virtual Task DeleteAllAsync()
        {
            entities.RemoveRange(entities);
            await SaveChangesAsync().ConfigureAwait(false);
        }

        private async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
