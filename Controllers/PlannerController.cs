using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DreamDayWeddingPlanningManagementSystem.Data;
using DreamDayWeddingPlanningManagementSystem.Models;
using System.Linq;

namespace DreamDayWeddingPlanningManagementSystem.Controllers
{
    public class PlannerController : Controller
    {
        private readonly AppDbContext _context;
        public PlannerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Planner/Index
        public IActionResult Index()
        {
            var weddings = _context.Weddings
                .Include(w => w.ChecklistItems)
                .Include(w => w.Guests)
                .ToList();
            return View(weddings);
        }
    }
}
