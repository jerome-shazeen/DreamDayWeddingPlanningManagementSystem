using System.ComponentModel.DataAnnotations;

namespace DreamDayWeddingPlanningManagementSystem.Models
{
    public class Guest
    {
        [Key]
        public int GuestId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        public bool RSVP { get; set; }

        public int WeddingId { get; set; }
        public virtual Wedding Wedding { get; set; }
    }
}
