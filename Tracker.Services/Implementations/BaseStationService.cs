using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Entity;
using Tracker.Entity.Contract;
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
                Include(q => q.DCNRouters).
                FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<BTS>?> GetFilteredResultAsync(string? filterOn, string? filterQuery, int pageNumber, int pageSize)
        {
            var allResult = context.Set<BTS>().
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
                if (filterOn.Equals(nameof(BTS.BTSName), StringComparison.OrdinalIgnoreCase))
                {
                    filteredResult = filteredResult.Where(q => q.BTSName.Contains(filterQuery));
                }
                else if (filterOn.Equals(nameof(BTS.LocationAddress), StringComparison.OrdinalIgnoreCase))
                {
                    filteredResult = filteredResult.Where(q => q.LocationAddress.Contains(filterQuery));
                }
                else if (filterOn.Equals(nameof(BTS.State.StateName), StringComparison.OrdinalIgnoreCase))
                {
                    filteredResult = filteredResult.Where(q => q.State.StateName.Contains(filterQuery));
                }
                else if (filterOn.Equals(nameof(BTS.State.Region.RegionName), StringComparison.OrdinalIgnoreCase))
                {
                    filteredResult = filteredResult.Where(q => q.State.Region.RegionName.Contains(filterQuery));
                }
            }

            //Pagination
            var skipResults = (pageNumber - 1) * pageSize;

            return await filteredResult.Skip(skipResults).Take(pageSize).ToListAsync();
        }

    }
}
