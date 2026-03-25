using DreamDayWeddingPlanningManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace DreamDayWeddingPlanningManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // User and Vendor Modules
        public DbSet<User> Users { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Service> Services { get; set; }

        // Wedding Planning Modules
        public DbSet<Wedding> Weddings { get; set; }
        public DbSet<ChecklistItem> ChecklistItems { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<BudgetItem> BudgetItems { get; set; }
        public DbSet<TimelineEvent> TimelineEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Service>()
                .Property(s => s.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<BudgetItem>()
                .Property(b => b.Amount)
                .HasPrecision(18, 2);

        }
    }
}


