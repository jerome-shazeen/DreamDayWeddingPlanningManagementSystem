using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DreamDayWeddingPlanningManagementSystem.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        [Required]
        public string ServiceName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int VendorId { get; set; }
        [ForeignKey("VendorId")]
        public virtual Vendor Vendor { get; set; }
    }
}
