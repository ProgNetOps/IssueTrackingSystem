using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Entity.Contract;

namespace Tracker.Entity
{
    /// <summary>
    /// Class that represents the client/customer
    /// </summary>
    public class Client:IEntityBase
    {  

        #region Properties
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// This uniquely identifies a client; required for staff in client's establishment to create trouble tickets
        /// </summary>
        [Required]
        public Guid ClientRef { get; set; }

        /// <summary>
        /// Name of client/customer
        /// </summary>
        [Required]
        [StringLength(100)]
        public string? ClientName { get; set; }
        
        //public List<Circuit>? Circuits { get; set; }
        #endregion
    }

}
