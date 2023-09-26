using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Tracker.Entity;

namespace Tracker.Models.DTOs
{
    public class CircuitTechnicalDetailsDTO
    {
        [Key]
        public int Id { get; set; }

        public int? CircuitId { get; set; }
        [ForeignKey(nameof(CircuitId))]
        public Circuit? Circuit { get; set; }

        [Display(Name = "Last Mile Medium")]
        [StringLength(50)]
        public string? LastMileMedium { get; set; }

        [Display(Name = "Last Mile Equipment Type")]
        [StringLength(50)]
        public string? LastMileEquipmentType { get; set; }

        [Display(Name = "Last Mile Equipment Specs")]
        [StringLength(300)]
        public string? LastMileEquipmentSpecs { get; set; }

        [Display(Name = "IP PoP")]
        public int? IPPoPId { get; set; }
        [ForeignKey(nameof(IPPoPId))]
        public IPPoP? IPPoP { get; set; }


        [Display(Name = "MPLS PoP")]
        public int? MPLSPoPId { get; set; }
        [ForeignKey(nameof(MPLSPoPId))]
        public MPLSPoP? MPLSPoP { get; set; }

        [Display(Name = "Transmission Path")]

        [StringLength(200)]
        public string? TransmissionPath { get; set; }

        [Display(Name = "Path Length")]
        public double? PathLength { get; set; }

        [Display(Name = "Radio Management VLAN")]
        [StringLength(10)]
        public string? RadioManagementVLAN { get; set; }

        [StringLength(50)]
        public string? Gateway { get; set; }

        [Display(Name = "Glo BTS Radio IP")]
        [StringLength(50)]
        public string? PoPRadioIP { get; set; }

        [Display(Name = "Client Radio IP")]
        [StringLength(50)]
        public string? ClientRadioIP { get; set; }

        [Display(Name ="JCC Approval Date")]
        [StringLength(50)]
        public string? JCCApprovalDate { get; set; }
    }
}
