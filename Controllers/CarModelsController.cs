using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarSale.Data;
using CarSale.Models;
using CarSale.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace CarSale.Controllers
{
    public class CarModelsController : Controller
    {
        private readonly CarSaleDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CarModelsController(CarSaleDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        //seeding 
        public ActionResult SeedDB()
        {
            if (_context.CarModel.Count() == 0)
            {
              //  CarModel car1 = new CarModel { Make = "Ford", Model = "Mustang", Year = 2015, Color = "Blue", Engine = "2.0" };
             //   CarModel car2 = new CarModel { Make = "Chevrolet", Model = "Corvette", Year = 2016, Color = "Red", Engine = "3.0" };
            //    _context.CarModel.AddRange(car1, car2);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        //// GET: CarModels
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.CarModel.ToListAsync());
        //}

        // GET: CarModels
        public async Task<IActionResult> Index(string searchString )
        {
            var cars = from s in _context.CarModel
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(s => s.Make.Contains(searchString) || s.Model.Contains(searchString));
            }

       
            return View(await cars.ToListAsync());
        }

        // GET:  new car and Models
        public async Task<IActionResult> NewCar(string searchString, int? FromYear, int? ToYear, int? FromPrice, int? ToPrice,int? FromMileage, int? ToMileage)
        {
            var cars = from s in _context.CarModel
                       select s;
            cars = cars.Where(s => s.isUsed == false);
            if (!String.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(s => s.Make.Contains(searchString) || s.Model.Contains(searchString));
            }
            if (FromYear.HasValue && ToYear.HasValue )
            {
                cars = cars.Where(s => s.Year >= FromYear && s.Year <= ToYear);
            }
            if (FromPrice.HasValue && ToPrice.HasValue)
            {
                cars = cars.Where(s => s.Price >= FromPrice && s.Price <= ToPrice);
            }
            if (FromMileage.HasValue && ToMileage.HasValue)
            {
                cars = cars.Where(s => s.Mileage >= FromMileage && s.Mileage <= ToMileage);
            }
            return View(await cars.ToListAsync());
        }

        // GET:  new car and Models
        public async Task<IActionResult> UsedCar(string searchString, int? FromYear, int? ToYear, int? FromPrice, int? ToPrice, int? FromMileage, int? ToMileage)
        {
            var cars = from s in _context.CarModel
                       select s;

            cars = cars.Where(s => s.isUsed == true);
            if (!String.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(s => s.Make.Contains(searchString) || s.Model.Contains(searchString));
            }
            if (FromYear.HasValue && ToYear.HasValue)
            {
                cars = cars.Where(s => s.Year >= FromYear && s.Year <= ToYear);
            }
            if (FromPrice.HasValue && ToPrice.HasValue)
            {
                cars = cars.Where(s => s.Price >= FromPrice && s.Price <= ToPrice);
            }
            if (FromMileage.HasValue && ToMileage.HasValue)
            {
                cars = cars.Where(s => s.Mileage >= FromMileage && s.Mileage <= ToMileage);
            }
            return View(await cars.ToListAsync());
        }

        // GET: CarModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carModel = await _context.CarModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carModel == null)
            {
                return NotFound();
            }

            return View(carModel);
        }



        // GET: CarModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Make,Model,Year,Color,Engine,Price,Mileage,CarImage")] CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carModel);
        }

        // GET: CarModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carModel = await _context.CarModel.FindAsync(id);
            if (carModel == null)
            {
                return NotFound();
            }
            return View(carModel);
        }

        // POST: CarModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Make,Model,Year,Color,Engine,Price,Mileage,CarImage")] CarModel carModel)
        {
            if (id != carModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarModelExists(carModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(carModel);
        }

        // GET: CarModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carModel = await _context.CarModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carModel == null)
            {
                return NotFound();
            }

            return View(carModel);
        }

        // POST: CarModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carModel = await _context.CarModel.FindAsync(id);
            _context.CarModel.Remove(carModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarModelExists(int id)
        {
            return _context.CarModel.Any(e => e.Id == id);
        }

        private string UploadedFile(CarViewModel model)
        {
            string uniqueFileName = null;

            if (model.CarImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.CarImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.CarImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
