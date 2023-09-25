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
        [Display(Name ="Circuit Reference")]
        public Guid CircuitRef { get; set; }

        /// <summary>
        /// The Id of the client
        /// </summary>
        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        [Display(Name ="Client Name")]
        public ClientDTO Client { get; set; }

        /// <summary>
        /// Name of Client
        /// </summary>
        [Required]
        [StringLength(100)]
        [Display(Name ="Circuit")]
        public string? CircuitName { get; set; }

        /// <summary>
        /// Address of client
        /// </summary>
        [StringLength(200)]
        [Display(Name ="Address")]
        public string? Address { get; set; }

        /// <summary>
        /// Town where client's office is situated
        /// </summary>
        [StringLength(50)]
        [Display(Name = "Town")]
        public string? Town { get; set; }

        /// <summary>
        /// State of the federation where customer is situated
        /// </summary>
        public int StateId { get; set; }
        [ForeignKey(nameof(StateId))]
        public StateDTO State { get; set; }

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

        [Display(Name = "Service Type")]
        public string? ServiceType { get; set; }

        [Display(Name = "JCC Approval Date")]
        public DateTime? JCCApprovedDate { get; set; }

        [Display(Name = "Annual Revenue")]
        public double? AnnualRevenue { get; set; }

        [Display(Name ="Bandwidth (Mbps)")]
        public double? Bandwidth { get; set; }

        public string? CircuitState { get; set; }

        [Display(Name = "Account Manager")]
        public string? AccountManager { get; set; }

        [Display(Name = "Project Manager")]
        public string? ProjectManager { get; set; }

        [Display(Name = "Technical Account Manager")]
        public string? TAM { get; set; }
        //[StringLength(500,ErrorMessage ="Maximum character count is 500")]
        //public string? ContactPersonsDetails { get; set; }
        //public int MPLSPoPId { get; set; }
        //[ForeignKey(nameof(MPLSPoPId))]
        //public MPLSPoPDTO? MPLSPoP { get; set; }

    }
}
