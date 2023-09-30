using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tracker.Entity;
using Tracker.Persistence;
using Tracker.Services.Base;
using Tracker.Services.Services;

namespace Tracker.Services.Implementations
{
    public class IPPoPService:SQLBaseRepository<IPPoP>,IIPPoPService
    {
        private readonly AppDbContext context;

        public IPPoPService(AppDbContext context): base(context)
        {
            this.context = context;
        }

        public async override Task<IEnumerable<IPPoP>?> GetAllAsync()
        {
            return await context.Set<IPPoP>().
                Include(q => q.BTS).
                ThenInclude(q => q.State).
                Include(q => q.Switches).
                ToListAsync();
        }

        public async override Task<IPPoP?> GetByIdAsync(int id)
        {
            return await context.Set<IPPoP>().
                Include(q => q.BTS).
                ThenInclude(q => q.State).
                Include(q => q.Switches).
                FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
