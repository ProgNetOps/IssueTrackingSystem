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
    public class StateService: SQLBaseRepository<State>, IStateService
    {
        private readonly AppDbContext context;
        public StateService(AppDbContext context):base(context)
        {
            this.context = context;
        }
    }
}
