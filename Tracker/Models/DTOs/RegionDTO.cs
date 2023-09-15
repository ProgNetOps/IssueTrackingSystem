using System.ComponentModel.DataAnnotations;
using Tracker.Entity;

namespace Tracker.Models.DTOs
{
    public class RegionDTO
    {
        [Key]
        public int Id { get; set; }


        /// <summary>
        /// Name of the region or zone
        /// </summary>
        [Required]
        [StringLength(15)]
        public string RegionName { get; set; }


        /// <summary>
        /// List of states in the region
        /// </summary>
        public List<StateDTO>? States { get; set; }
    }
}
