using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Tracker.Entity;

namespace Tracker.Models.DTOs
{
    public class CircuitDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        /// <summary>
        /// This uniquely identifies a link
        /// </summary>
        public Guid CircuitRef { get; set; }

        /// <summary>
        /// The Id of the client
        /// </summary>
        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public ClientDTO Client { get; set; }

        /// <summary>
        /// Name of Client
        /// </summary>
        [Required]
        [StringLength(100)]
        public string CircuitName { get; set; }

        /// <summary>
        /// Address of client
        /// </summary>
        [StringLength(200)]
        public string? Address { get; set; }

        /// <summary>
        /// Town where client's office is situated
        /// </summary>
        [StringLength(50)]
        public string? Town { get; set; }

        /// <summary>
        /// State of the federation where customer is situated
        /// </summary>
        public int StateId { get; set; }
        [ForeignKey(nameof(StateId))]
        public State State { get; set; }

        /// <summary>
        /// The latitude coordinate of the base station
        /// </summary>
        public double? Latitude { get; set; }

        /// <summary>
        /// The longitude coordinate of the base station
        /// </summary>
        public double? Longitude { get; set; }

        /// <summary>
        /// Coordinates in degrees, minutes and seconds
        /// </summary>
        public string? Coordinates { get; set; }

        public string? ServiceType { get; set; }

        public DateTime? JCCApprovedDate { get; set; }

        public double? AnnualRevenue { get; set; }

        public double? Bandwidth { get; set; }

        public string? CircuitState { get; set; }

        public string? AccountManager { get; set; }
        public string? ProjectManager { get; set; }
        public string? TAM { get; set; }

    }
}
