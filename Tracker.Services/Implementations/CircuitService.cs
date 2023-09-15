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
    public class CircuitService: SQLBaseRepository<Circuit>, ICircuitService
    {
        private readonly AppDbContext context;

        public CircuitService(AppDbContext context):base(context)
        {
            this.context = context;
        }

        public async override Task<Circuit?> GetByIdAsync(int id)
        {
            return await context.Circuits.Include(q => q.State).
                Include(q => q.Client).
                FirstOrDefaultAsync(q => q.Id == id);
        }

    }
}
