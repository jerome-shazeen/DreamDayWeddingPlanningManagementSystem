using Microsoft.AspNetCore.Mvc;
using DreamDayWeddingPlanningManagementSystem.Data;
using DreamDayWeddingPlanningManagementSystem.Models;
using System.Linq;

namespace DreamDayWeddingPlanningManagementSystem.Controllers
{
    public class ChecklistController : Controller
    {
        private readonly AppDbContext _context;
        public ChecklistController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Checklist/Index
        public IActionResult Index()
        {
            var checklistItems = _context.Set<ChecklistItem>().Where(c => c.WeddingId == 1).ToList();
            return View(checklistItems);
        }

        // GET: /Checklist/Create
        public IActionResult Create() => View();

        // POST: /Checklist/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ChecklistItem item)
        {
            if (ModelState.IsValid)
            {
                item.WeddingId = 1;
                _context.Set<ChecklistItem>().Add(item);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }
    }
}
