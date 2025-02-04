using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarServiceApp.Models;
using CarServiceApp.Data;

namespace CarServiceApp.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchQuery, string searchField)
        {
            var cars = _context.Cars.Include(c => c.RepairCase).AsQueryable();

            if (!string.IsNullOrEmpty(searchQuery) && !string.IsNullOrEmpty(searchField))
            {
                switch (searchField)
                {
                    case "Id":
                        if (int.TryParse(searchQuery, out int id))
                            cars = cars.Where(c => c.Id == id);
                        break;
                    case "Brand":
                        cars = cars.Where(c => c.Brand.Contains(searchQuery));
                        break;
                    case "Model":
                        cars = cars.Where(c => c.Model.Contains(searchQuery));
                        break;
                    case "Year":
                        if (int.TryParse(searchQuery, out int year))
                            cars = cars.Where(c => c.Year == year);
                        break;
                    case "Vin":
                        cars = cars.Where(c => c.Vin.Contains(searchQuery));
                        break;
                    case "EngineType":
                        cars = cars.Where(c => c.EngineType.Contains(searchQuery));
                        break;
                }
            }

            return View(cars.ToList());
        }


        public IActionResult Details(int id)
        {
            var car = _context.Cars
                .Include(c => c.RepairCase)
                .FirstOrDefault(c => c.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            return PartialView("_DetailsPartial", car);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(car.PhotoPath) ||
                    !System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", car.PhotoPath.TrimStart('/'))))
                {
                    car.PhotoPath = "/content/def.png";
                }

                _context.Cars.Add(car);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        public IActionResult Edit(int id)
        {
            var car = _context.Cars
                .Include(c => c.RepairCase)
                .FirstOrDefault(c => c.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                var existingCar = _context.Cars
                    .Include(c => c.RepairCase)
                    .FirstOrDefault(c => c.Id == car.Id);

                if (existingCar == null)
                {
                    return NotFound();
                }

                existingCar.Brand = car.Brand;
                existingCar.Model = car.Model;
                existingCar.Year = car.Year;
                existingCar.Vin = car.Vin;
                existingCar.EngineType = car.EngineType;
                existingCar.PhotoPath = string.IsNullOrWhiteSpace(car.PhotoPath) ? "/content/def.png" : car.PhotoPath;

                if (existingCar.RepairCase != null && car.RepairCase != null)
                {
                    existingCar.RepairCase.RepairHistory = car.RepairCase.RepairHistory;
                    existingCar.RepairCase.UnresolvedIssues = car.RepairCase.UnresolvedIssues;
                }
                else if (car.RepairCase != null)
                {
                    existingCar.RepairCase = new RepairCase
                    {
                        RepairHistory = car.RepairCase.RepairHistory,
                        UnresolvedIssues = car.RepairCase.UnresolvedIssues
                    };
                }

                _context.Update(existingCar);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(car);
        }

        public IActionResult Delete(int id)
        {
            var car = _context.Cars
                .Include(c => c.RepairCase)
                .FirstOrDefault(c => c.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var car = _context.Cars
                .Include(c => c.RepairCase)
                .FirstOrDefault(c => c.Id == id);

            if (car != null)
            {
                if (car.RepairCase != null)
                {
                    _context.RepairCases.Remove(car.RepairCase);
                }

                _context.Cars.Remove(car);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
