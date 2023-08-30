using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tracker.Entity.Contract;

namespace Tracker.Entity
{
    /// <summary>
    /// Class that represents the State of the Federation
    /// </summary>
    public class State : IEntityBase
    {

        #region Properties
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of the State
        /// </summary>
        [Required]
        [StringLength(20)]
        [Display(Name = "State")]
        public string StateName { get; set; }

        public int RegionId { get; set; }

        [ForeignKey(nameof(RegionId))]
        public Region? Region { get; set; }
        #endregion
    }
}
