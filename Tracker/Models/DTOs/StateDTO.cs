using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Tracker.Entity;

namespace Tracker.Models.DTOs
{
    public class StateDTO
    {
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
        public RegionDTO? Region { get; set; }
    }
}
