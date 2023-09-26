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
    public class CircuitTechnicalDetails:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public int? CircuitId { get; set; }
        [ForeignKey(nameof(CircuitId))]
        public Circuit? Circuit { get; set; }

        [StringLength(50)]
        public string? LastMileMedium { get; set; }

        [StringLength(50)]
        public string? LastMileEquipmentType { get; set; }

        [StringLength(300)]
        public string? LastMileEquipmentSpecs { get; set; }

        public int? IPPoPId { get; set; }
        [ForeignKey(nameof(IPPoPId))]
        public IPPoP? IPPoP { get; set; }

        public int? MPLSPoPId { get; set; }
        [ForeignKey(nameof(MPLSPoPId))]
        public MPLSPoP? MPLSPoP { get; set; }

        [StringLength(200)]
        public string? TransmissionPath { get; set; }

        public double? PathLength { get; set; }

        [StringLength(50)]
        public string? RadioManagementVLAN { get; set; 
        }
        [StringLength(50)]
        public string? Gateway { get; set; }

        [StringLength(50)]
        public string? PopRadioIP { get; set; }

        [StringLength(50)]
        public string? ClientRadioIP { get; set; }

        [StringLength(50)]
        public string? JCCApprovalDate { get; set; }

    }
}
