using System;
using System.ComponentModel.DataAnnotations;

namespace DreamDayWeddingPlanningManagementSystem.Models
{
    public class TimelineEvent
    {
        [Key]
        public int TimelineEventId { get; set; }

        [Required(ErrorMessage = "Event name is required.")]
        public string EventName { get; set; } = string.Empty;

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int WeddingId { get; set; }
        public virtual Wedding? Wedding { get; set; }
    }
}
