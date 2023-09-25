using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Tracker.Entity;

namespace Tracker.Models.DTOs
{
    public class MPLSPoPDTO
    {
        #region Properties
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Foreign key for the base station where router is located
        /// </summary>
        public int BTSId { get; set; }
        [ForeignKey(nameof(BTSId))]
        public BTS? BTS { get; set; }

        /// <summary>
        /// Name of router
        /// </summary>
        [Required]
        [Display(Name = "NE Name")]
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

        public List<CircuitDTO>? Circuits { get; set; }

        #endregion
    }
}
