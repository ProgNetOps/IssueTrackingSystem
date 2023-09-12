using System.ComponentModel.DataAnnotations;

namespace Tracker.Models.DTOs
{
    public class ClientDTO
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
