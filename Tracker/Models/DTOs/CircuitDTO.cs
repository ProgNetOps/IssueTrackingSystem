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
        [Display(Name ="Service Address")]
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


        [Display(Name = "Annual Revenue")]
        public double? AnnualRevenue { get; set; }

        [Display(Name ="Bandwidth (Mbps)")]
        public double? Bandwidth { get; set; }

        [Display(Name = "Link Status")]
        public string? CircuitState { get; set; }

        [Display(Name = "Account Manager")]
        public string? AccountManager { get; set; }

        [Display(Name = "Project Manager")]
        public string? ProjectManager { get; set; }

        [Display(Name = "Technical Account Manager")]
        public string? TAM { get; set; }

        [StringLength(50)]
        [Display(Name = "Last Mile Medium")]
        public string? LastMileMedium { get; set; }

        [StringLength(50)]
        [Display(Name = "Equipment Type")]
        public string? LastMileEquipmentType { get; set; }

        [StringLength(300)]
        [Display(Name = "Last Mile Device Specs")]
        public string? LastMileEquipmentSpecs { get; set; }

        public int? IPPoPId { get; set; }
        [ForeignKey(nameof(IPPoPId))]
        [Display(Name = "IP PoP")]
        public IPPoP? IPPoP { get; set; }

        public int? MPLSPoPId { get; set; }
        [ForeignKey(nameof(MPLSPoPId))]
        [Display(Name = "MPLS PoP")]
        public MPLSPoP? MPLSPoP { get; set; }

        [StringLength(200)]
        [Display(Name = "Transmission Path")]
        public string? TransmissionPath { get; set; }

        [Display(Name = "Transmission Path Length")]
        public double? PathLength { get; set; }

        [StringLength(50)]
        [Display(Name = "Radio Management VLAN")]
        public string? RadioManagementVLAN { get; set; }

        [StringLength(50)]
        [Display(Name = "Gateway")]
        public string? Gateway { get; set; }

        [StringLength(50)]
        [Display(Name = "PoP Radio IP")]
        public string? PopRadioIP { get; set; }

        [StringLength(50)]
        [Display(Name = "Client Radio IP")]
        public string? ClientRadioIP { get; set; }

        [StringLength(50)]
        [Display(Name = "Service Start Date")]
        public string? ServiceStartDate { get; set; }

    }
}
