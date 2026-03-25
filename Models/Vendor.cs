using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DreamDayWeddingPlanningManagementSystem.Models
{
    public class Vendor
    {
        [Key]
        public int VendorId { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        // Navigation property for services
        public virtual ICollection<Service> Services { get; set; }
    }
}
