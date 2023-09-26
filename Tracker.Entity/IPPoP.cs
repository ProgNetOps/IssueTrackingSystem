using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Entity.Contract;

namespace Tracker.Entity
{
    public class IPPoP:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public int? BTSId { get; set; }
        [ForeignKey(nameof(BTSId))]
        public BTS? BTS { get; set; }

        public List<NetworkSwitch>? Switches { get; set; }
    }
}
