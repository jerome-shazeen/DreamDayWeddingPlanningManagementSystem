using System.ComponentModel.DataAnnotations;

namespace DreamDayWeddingPlanningManagementSystem.Models
{
    public class BudgetItem
    {
        [Key]
        public int BudgetItemId { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public int WeddingId { get; set; }
        public virtual Wedding? Wedding { get; set; }
    }
}
