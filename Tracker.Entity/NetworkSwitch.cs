using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Entity.Contract;

namespace Tracker.Entity
{
    /// <summary>
    /// Represents the switch on which clients' services are configured
    /// </summary>
    public class NetworkSwitch:IEntityBase
    {
        #region Properties
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
        [StringLength(7000)]
        public string? ConfigBackup { get; set; }

        /// <summary>
        /// Last date of switch config backup
        /// </summary>
        public DateTime? DateOfLastBackup { get; set; }

        /*//FOR LATER
        /// <summary>
        /// The staff who effected the last backup
        /// </summary>
        public int EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
        */
        #endregion
    }
}
