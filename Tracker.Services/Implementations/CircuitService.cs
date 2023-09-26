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



        //public async override Task<ICircuit?> GetAllAsync()
        //{
        //    return await context.Circuits.Include(q => q.State).
        //        Include(q => q.Client).
        //        Include(q => q.MPLSPoP).
        //        FirstOrDefaultAsync(q => q.Id == id);
        //}
        public async override Task<IEnumerable<Circuit>?> GetAllAsync()
        {
            return await context.Set<Circuit>().
                Include(q => q.State).
                Include(q => q.Client).
                //Include(q => q.MPLSPoP).
                ToListAsync();
        }

        public async override Task<Circuit?> GetByIdAsync(int id)
        {
            return await context.Circuits.
                Include(q => q.TechnicalDetails).
                Include(q => q.State).
                Include(q => q.Client).
                //Include(q => q.MPLSPoP).
                FirstOrDefaultAsync(q => q.Id == id);
        }


        public async Task<IEnumerable<Circuit>?> GetFilteredResultAsync(string? filterOn, string? filterQuery, int pageNumber, int pageSize)
        {
            var allResult = context.Set<Circuit>().
                Include(q => q.State).
                ThenInclude(q => q.Region).AsQueryable();
            var filteredResult = allResult;

            if (string.IsNullOrWhiteSpace(filterOn) || string.IsNullOrWhiteSpace(filterQuery))
            {
                filteredResult = filteredResult.Take(50).AsQueryable();
            }


            //Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals(nameof(Circuit.CircuitName), StringComparison.OrdinalIgnoreCase))
                {
                    filteredResult = filteredResult.Where(q => q.CircuitName.Contains(filterQuery));
                }
                else if (filterOn.Equals(nameof(Circuit.Address), StringComparison.OrdinalIgnoreCase))
                {
                    filteredResult = filteredResult.Where(q => q.Address.Contains(filterQuery));
                }
                else if (filterOn.Equals(nameof(Circuit.Town), StringComparison.OrdinalIgnoreCase))
                {
                    filteredResult = filteredResult.Where(q => q.Town.Contains(filterQuery));
                }
                else if (filterOn.Equals(nameof(Circuit.State.StateName), StringComparison.OrdinalIgnoreCase))
                {
                    filteredResult = filteredResult.Where(q => q.State.StateName.Contains(filterQuery));
                }
                else if (filterOn.Equals(nameof(Circuit.State.Region.RegionName), StringComparison.OrdinalIgnoreCase))
                {
                    filteredResult = filteredResult.Where(q => q.State.Region.RegionName.Contains(filterQuery));
                }
                else if (filterOn.Equals(nameof(Circuit.AccountManager), StringComparison.OrdinalIgnoreCase))
                {
                    filteredResult = filteredResult.Where(q => q.AccountManager.Contains(filterQuery));
                }
                else if (filterOn.Equals(nameof(Circuit.ProjectManager), StringComparison.OrdinalIgnoreCase))
                {
                    filteredResult = filteredResult.Where(q => q.ProjectManager.Contains(filterQuery));
                }
                else if (filterOn.Equals(nameof(Circuit.TAM), StringComparison.OrdinalIgnoreCase))
                {
                    filteredResult = filteredResult.Where(q => q.TAM.Contains(filterQuery));
                }

            }

            //Pagination
            var skipResults = (pageNumber - 1) * pageSize;

            return await filteredResult.Skip(skipResults).Take(pageSize).ToListAsync();
        }


    }
}
