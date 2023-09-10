using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Entity;
using Tracker.Services.Base;

namespace Tracker.Services.Services
{
    public interface IClientService : IEntityBaseRepository<Client>
    {
    }
}
