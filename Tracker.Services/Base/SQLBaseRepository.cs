using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Entity.Contract;
using Tracker.Persistence;

namespace Tracker.Services.Base
{
    public class SQLBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext context;

        public SQLBaseRepository(AppDbContext context)
        {
            this.context = context;
        }


        public async virtual Task<IEnumerable<T>?> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async virtual Task<T?> GetByIdAsync(int id)
        {
            return await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            if (entity != null)
            {
                EntityEntry entityEntry = context.Entry<T>(entity);
                entityEntry.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(T entity)
        {
            EntityEntry entityEntry = context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        
    }
}
