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
    public class EmployeeService: SQLBaseRepository<Employee>, IEmployeeService
    {
        private readonly AppDbContext context;
        public EmployeeService(AppDbContext context):base(context)
        {
            this.context = context;
        }

        public Task<IEnumerable<Employee>?> GetFilteredResultAsync(string filterOn, string filterQuery, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
