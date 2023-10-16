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
    /// <summary>
    /// Class that represents the MPLSPoP
    /// </summary>
    public class MPLSPoP:IEntityBase
    {
        #region Properties
    
        /// <summary>
        /// Name of router
        /// </summary>
        [Required]
        [Display(Name ="NE Name")]
        [StringLength(50)]
        public string? NEName { get; set; }

        /// <summary>
        /// Type of router
        /// </summary>
        [Required]
        [Display(Name = "NE Type (MPU Type)")]
        [StringLength(50)]
        public string? NEType { get; set; }

        /// <summary>
        /// IP Address of router device
        /// </summary>
        [Required]
        [Display(Name = "NE IP Address")]
        [StringLength(15)]
        public string? NEIpAddress { get; set; }

        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Foreign key for the base station where router is located
        /// </summary>
        public int BTSId { get; set; }
        [ForeignKey(nameof(BTSId))]
        public BTS? BTS { get; set; }
                
        public List<DCNRouter>? Routers { get; set; }

        public List<Circuit>? Circuits { get; set; }

        #endregion
    }

}
