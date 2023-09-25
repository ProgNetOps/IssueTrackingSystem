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
    public class ClientService: SQLBaseRepository<Client>, IClientService
    {
        private readonly AppDbContext context;

        public ClientService(AppDbContext context):base(context)
        {
            this.context = context;
        }

       public async override Task<Client?> GetByIdAsync(int id)
        {
           return await context.Clients.
                Include(q => q.Circuits).
                ThenInclude(q => q.State).
                FirstOrDefaultAsync(q => q.Id == id);

        }

        public async Task<IEnumerable<Client>?> GetFilteredResultAsync(string? filterOn, string? filterQuery, int pageNumber, int pageSize)
        {
            var allResult = context.Set<Client>().AsQueryable();
            var filteredResult = allResult;

            if (string.IsNullOrWhiteSpace(filterOn) || string.IsNullOrWhiteSpace(filterQuery))
            {
                filteredResult = filteredResult.Take(50).AsQueryable();
            }



            //Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals(nameof(Client.ClientName), StringComparison.OrdinalIgnoreCase))
                {
                    filteredResult = filteredResult.Where(q => q.ClientName.Contains(filterQuery));
                }
            }

            //Pagination
            var skipResults = (pageNumber - 1) * pageSize;

            return await filteredResult.Skip(skipResults).Take(pageSize).ToListAsync();
        }

    }
}
