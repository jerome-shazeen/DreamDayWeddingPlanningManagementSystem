using System.Collections.Generic;

namespace DreamDayWeddingPlanningManagementSystem.Models
{
    public class AdminDashboardViewModel
    {
        public List<User> Users { get; set; } = new List<User>();
        public List<Vendor> Vendors { get; set; } = new List<Vendor>();
    }
}
