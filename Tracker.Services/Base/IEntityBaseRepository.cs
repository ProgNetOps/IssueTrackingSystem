using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Entity.Contract;

namespace Tracker.Services.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        //All
        Task<IEnumerable<T>?> GetAllAsync();

        //Read
        Task<T?> GetByIdAsync(int id);

        //Create
        Task AddAsync(T entity);

        //Update
        Task UpdateAsync(T entity);

        //Delete
        Task DeleteAsync(int id);
    }
}
