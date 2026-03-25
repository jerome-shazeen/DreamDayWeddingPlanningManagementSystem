using Microsoft.AspNetCore.Mvc;
using DreamDayWeddingPlanningManagementSystem.Data;
using DreamDayWeddingPlanningManagementSystem.Models;
using System.Linq;

namespace DreamDayWeddingPlanningManagementSystem.Controllers
{
    public class BudgetController : Controller
    {
        private readonly AppDbContext _context;
        public BudgetController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Budget/Index
        public IActionResult Index()
        {
            var items = _context.Set<BudgetItem>().Where(b => b.WeddingId == 1).ToList();
            return View(items);
        }
    }
}
