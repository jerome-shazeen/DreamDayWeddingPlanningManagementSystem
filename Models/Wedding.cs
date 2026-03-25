using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DreamDayWeddingPlanningManagementSystem.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId { get; set; }

        [Required(ErrorMessage = "Wedding title is required.")]
        public string Title { get; set; } = string.Empty;

        public DateTime WeddingDate { get; set; }
        public string Venue { get; set; } = string.Empty;

        public int UserId { get; set; }
        public virtual User? Couple { get; set; }

        public virtual ICollection<ChecklistItem> ChecklistItems { get; set; } = new List<ChecklistItem>();
        public virtual ICollection<Guest> Guests { get; set; } = new List<Guest>();
        public virtual ICollection<BudgetItem> BudgetItems { get; set; } = new List<BudgetItem>();
        public virtual ICollection<TimelineEvent> TimelineEvents { get; set; } = new List<TimelineEvent>();
    }
}
