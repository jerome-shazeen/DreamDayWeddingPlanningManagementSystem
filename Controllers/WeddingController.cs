using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DreamDayWeddingPlanningManagementSystem.Data;
using DreamDayWeddingPlanningManagementSystem.Models;
using System.Linq;

namespace DreamDayWeddingPlanningManagementSystem.Controllers
{
    public class WeddingController : Controller
    {
        private readonly AppDbContext _context;

        public WeddingController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Wedding/Index
        public IActionResult Index()
        {
            int userId = 1;

            var wedding = _context.Weddings
                .Include(w => w.ChecklistItems)
                .Include(w => w.Guests)
                .Include(w => w.BudgetItems)
                .Include(w => w.TimelineEvents)
                .FirstOrDefault(w => w.UserId == userId);

            return View(wedding);
        }
    }
}
