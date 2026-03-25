using System;
using System.Linq;
using DreamDayWeddingPlanningManagementSystem.Models;

namespace DreamDayWeddingPlanningManagementSystem.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // Ensure the database is created.
            context.Database.EnsureCreated();

            // Check if any users already exist. If so, assume database has been seeded.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            // -------------------
            // Seed Admin Account
            // -------------------
            var admin = new User
            {
                FullName = "Administrator",
                Email = "admin@example.com",
                Password = "AdminPassword", // In production, hash your passwords!
                Role = "Admin"
            };
            context.Users.Add(admin);

            // -------------------
            // Seed Couple Users
            // -------------------
            var couples = new User[]
            {
                new User
                {
                    FullName = "John and Jane Doe",
                    Email = "johndoe@example.com",
                    Password = "Password123", // In production, hash your passwords!
                    Role = "Couple"
                }
            };
            foreach (var couple in couples)
            {
                context.Users.Add(couple);
            }
            context.SaveChanges();

            // -------------------
            // Seed Vendors
            // -------------------
            var vendors = new Vendor[]
            {
                new Vendor
                {
                    Name = "Elegant Events",
                    Email = "contact@elegantevents.com",
                    Password = "Password123", // In production, hash your passwords!
                    Description = "High-end wedding planning service"
                },
                new Vendor
                {
                    Name = "Dream Decorations",
                    Email = "info@dreamdecorations.com",
                    Password = "Password123",
                    Description = "Expert in wedding decorations"
                }
            };
            foreach (var vendor in vendors)
            {
                context.Vendors.Add(vendor);
            }
            context.SaveChanges();

            // -------------------
            // Seed a Wedding for the first couple (if needed)
            // -------------------
            var wedding = new Wedding
            {
                Title = "John & Jane's Wedding",
                WeddingDate = DateTime.Now.AddMonths(6),
                Venue = "The Grand Ballroom",
                UserId = couples[0].UserId, // Assumes the first couple in the array
                ChecklistItems = new System.Collections.Generic.List<ChecklistItem>(),
                Guests = new System.Collections.Generic.List<Guest>(),
                BudgetItems = new System.Collections.Generic.List<BudgetItem>(),
                TimelineEvents = new System.Collections.Generic.List<TimelineEvent>()
            };
            context.Weddings.Add(wedding);
            context.SaveChanges();

            // -------------------
            // Optionally, seed additional data (e.g., Services)
            // -------------------
            var services = new Service[]
            {
                new Service
                {
                    ServiceName = "Full Wedding Package",
                    Description = "Comprehensive wedding planning service",
                    Price = 5000m,
                    VendorId = vendors[0].VendorId
                },
                new Service
                {
                    ServiceName = "Consultation Package",
                    Description = "Wedding planning consultation",
                    Price = 1500m,
                    VendorId = vendors[1].VendorId
                }
            };
            foreach (var service in services)
            {
                context.Services.Add(service);
            }
            context.SaveChanges();
        }
    }
}
