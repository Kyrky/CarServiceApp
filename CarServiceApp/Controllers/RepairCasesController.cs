using Microsoft.AspNetCore.Mvc;
using CarServiceApp.Models;
using CarServiceApp.Data;

namespace CarServiceApp.Controllers
{
    public class RepairCasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RepairCasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create(int carId)
        {
            ViewBag.CarId = carId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RepairCase repairCase, int carId)
        {
            if (ModelState.IsValid)
            {
                _context.RepairCases.Add(repairCase);
                _context.SaveChanges();

                var car = _context.Cars.FirstOrDefault(c => c.Id == carId);
                if (car != null)
                {
                    car.RepairCaseId = repairCase.Id;
                    _context.SaveChanges();
                }

                return RedirectToAction("Index", "Cars");
            }

            ViewBag.CarId = carId;
            return View(repairCase);
        }

        public IActionResult Details(int id)
        {
            var repairCase = _context.RepairCases.FirstOrDefault(r => r.Id == id);
            if (repairCase == null)
            {
                return NotFound();
            }
            return View(repairCase);
        }
    }
}
