using Microsoft.AspNetCore.Mvc;
using DreamDayWeddingPlanningManagementSystem.Data;
using System.Linq;

namespace DreamDayWeddingPlanningManagementSystem.Controllers
{
    public class VendorCatalogController : Controller
    {
        private readonly AppDbContext _context;
        public VendorCatalogController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /VendorCatalog/Index
        public IActionResult Index()
        {
            var vendors = _context.Vendors.ToList();
            return View(vendors);
        }
    }
}
