using ActivityTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActivityTracker.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ActivitiesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Activities.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create([Bind("Name", "Date", "Summary")] Activities Activity)
        {
            if (ModelState.IsValid)
            {
                _db.Add(Activity);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Activity);
        }
    }
}
