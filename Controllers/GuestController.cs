using Microsoft.AspNetCore.Mvc;
using DreamDayWeddingPlanningManagementSystem.Data;
using DreamDayWeddingPlanningManagementSystem.Models;
using System.Linq;

namespace DreamDayWeddingPlanningManagementSystem.Controllers
{
    public class GuestController : Controller
    {
        private readonly AppDbContext _context;
        public GuestController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Guest/Index
        public IActionResult Index()
        {
            var guests = _context.Set<Guest>().Where(g => g.WeddingId == 1).ToList();
            return View(guests);
        }
    }
}
