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
    public class MPLSPoPService:SQLBaseRepository<MPLSPoP>,IMPLSPoPService
    {
        private readonly AppDbContext context;

        public MPLSPoPService(AppDbContext context):base(context)
        {
            this.context = context;
        }

        public async override Task<IEnumerable<MPLSPoP>?> GetAllAsync()
        {
            return await context.Set<MPLSPoP>().
                Include(q => q.BTS).
                ToListAsync();
        }

        public async override Task<MPLSPoP?> GetByIdAsync(int id)
        {
            return await context.Set<MPLSPoP>().
                Include(q => q.BTS).
                ThenInclude(q => q.State).
                Include(q => q.Circuits).
                FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
