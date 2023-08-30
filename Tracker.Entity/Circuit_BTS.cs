using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Entity
{
    public class Circuit_BTS
    {
        [Key]
        public int Id { get; set; }
        public int CircuitId { get; set; }
        public Circuit Circuit { get; set; }
        public int BTSId { get; set; }
        public BTS BTS { get; set; }
    }
}
