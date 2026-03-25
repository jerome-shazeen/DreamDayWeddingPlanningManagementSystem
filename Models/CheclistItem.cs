using System.ComponentModel.DataAnnotations;

namespace DreamDayWeddingPlanningManagementSystem.Models
{
    public class ChecklistItem
    {
        [Key]
        public int ChecklistItemId { get; set; }

        [Required(ErrorMessage = "Task description is required.")]
        public string Task { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }

        public int WeddingId { get; set; }

        public virtual Wedding? Wedding { get; set; }
    }
}
