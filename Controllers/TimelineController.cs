using Microsoft.AspNetCore.Mvc;
using DreamDayWeddingPlanningManagementSystem.Data;
using DreamDayWeddingPlanningManagementSystem.Models;
using System.Linq;

namespace DreamDayWeddingPlanningManagementSystem.Controllers
{
    public class TimelineController : Controller
    {
        private readonly AppDbContext _context;
        public TimelineController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Timeline/Index
        public IActionResult Index()
        {
            var events = _context.Set<TimelineEvent>().Where(e => e.WeddingId == 1).ToList();
            return View(events);
        }
    }
}
