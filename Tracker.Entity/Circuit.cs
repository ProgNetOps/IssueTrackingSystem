using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Entity.Contract;
using Tracker.Entity.Enums;

namespace Tracker.Entity
{

    /// <summary>
    /// Class that represents customer links
    /// </summary>
    public class Circuit:IEntityBase
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
        public Client Client { get; set; }

        /// <summary>
        /// Name of Client
        /// </summary>
        [Required]
        [StringLength(100)]
        public string CircuitName { get; set; }
        
        /// <summary>
        /// Address of client
        /// </summary>
        [StringLength(300)]
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

        [StringLength(50)]
        public string? Coordinates { get; set; }

        public string? ServiceType { get; set; }


        public double? AnnualRevenue { get; set; }

        public double? Bandwidth { get; set; }

        public string? CircuitState { get; set; }

        [StringLength(100)]
        public string? AccountManager { get; set; }

        [StringLength(100)]
        public string? ProjectManager { get; set; }

        [StringLength(100)]
        public string? TAM { get; set; }

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
        public string? RadioManagementVLAN
        {
            get; set;
        }
        [StringLength(50)]
        public string? Gateway { get; set; }

        [StringLength(50)]
        public string? PopRadioIP { get; set; }

        [StringLength(50)]
        public string? ClientRadioIP { get; set; }

        [StringLength(50)]
        public string? ServiceStartDate { get; set; }
        [StringLength(1000)]
        public string? ClientContactDetails { get; set; }
    }
}
