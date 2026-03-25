using Microsoft.AspNetCore.Mvc;
using DreamDayWeddingPlanningManagementSystem.Data;
using System.Linq;

namespace DreamDayWeddingPlanningManagementSystem.Controllers
{
    public class ReportsController : Controller
    {
        private readonly AppDbContext _context;
        public ReportsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Reports/Index
        public IActionResult Index()
        {
            var totalWeddings = _context.Weddings.Count();
            var reportData = new
            {
                TotalWeddings = totalWeddings,
            };
            return View(reportData);
        }
    }
}
