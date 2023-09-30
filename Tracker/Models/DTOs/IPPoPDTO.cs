using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Tracker.Entity;

namespace Tracker.Models.DTOs
{
    public class IPPoPDTO
    {
        [Key]
        public int Id { get; set; }

        public int? BTSId { get; set; }
        [ForeignKey(nameof(BTSId))]
        public BTSDTO? BTS { get; set; }

        public List<NetworkSwitchDTO>? Switches { get; set; }
    }
}
