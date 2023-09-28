using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Tracker.Entity;

namespace Tracker.Models.DTOs
{
    public class NetworkSwitchDTO
    {
        [Key]
        public int Id { get; set; }


        /// <summary>
        /// Name of switch
        /// </summary>
        [Required]
        [StringLength(30)]
        public string? SwitchName { get; set; }


        /// <summary>
        /// Switch IP for telnet sessions
        /// </summary>
        [Required]
        [StringLength(30)]
        public string? SwitchIP { get; set; }


        /// <summary>
        /// Base station where switch is located
        /// </summary>
        public int? IPPoPId { get; set; }
        [ForeignKey(nameof(IPPoPId))]
        public IPPoP? IPPoP { get; set; }


        /// <summary>
        /// The backup configuration of the switch
        /// </summary>
        [StringLength(5000)]
        public string? ConfigBackup { get; set; }


        /// <summary>
        /// Last date of switch config backup
        /// </summary>
        public DateTime? DateOfLastBackup { get; set; }
    }
}
