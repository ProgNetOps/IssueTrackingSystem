using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Entity;
using Tracker.Persistence;
using Tracker.Services.Base;
using Tracker.Services.Services;

namespace Tracker.Services.Implementations
{
    public class BaseStationService: SQLBaseRepository<BTS>, IBaseStationService
    {
        private readonly AppDbContext context;

        public BaseStationService(AppDbContext context):base(context)
        {
            this.context = context;
        }

        public async override Task<IEnumerable<BTS>?> GetAllAsync()
        {
            return await context.Set<BTS>().
                Include(q => q.State).
                ThenInclude(q => q.Region).ToListAsync();
        }

        public async override Task<BTS?> GetByIdAsync(int id)
        {
            return await context.Set<BTS>().
                Include(q => q.State).
                ThenInclude(q => q.Region).           
                FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
