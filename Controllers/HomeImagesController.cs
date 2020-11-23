using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarSale.Data;
using CarSale.Models;
using System.IO;
using CarSale.ViewModels;
using Microsoft.AspNetCore.Hosting;

namespace CarSale.Controllers
{
    public class HomeImagesController : Controller
    {
        private readonly CarSaleDbContext _context;

        public HomeImagesController(CarSaleDbContext context)
        {
            _context = context;
        }

        // GET: HomeImages
        public async Task<IActionResult> Index()
        {
            return View(await _context.HomeImage.ToListAsync());
        }

        // GET: HomeImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeImage = await _context.HomeImage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homeImage == null)
            {
                return NotFound();
            }

            return View(homeImage);
        }

        // GET: HomeImages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HomeImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Slide1,Slide2,Slide3")] HomeImage homeImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(homeImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(homeImage);
        }

        // GET: HomeImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeImage = await _context.HomeImage.FindAsync(id);
            if (homeImage == null)
            {
                return NotFound();
            }
            return View(homeImage);
        }

        // POST: HomeImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Slide1,Slide2,Slide3")] HomeImage homeImage)
        {
            if (id != homeImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homeImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeImageExists(homeImage.Id))
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
            return View(homeImage);
        }

        // GET: HomeImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeImage = await _context.HomeImage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homeImage == null)
            {
                return NotFound();
            }

            return View(homeImage);
        }

        // POST: HomeImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var homeImage = await _context.HomeImage.FindAsync(id);
            _context.HomeImage.Remove(homeImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeImageExists(int id)
        {
            return _context.HomeImage.Any(e => e.Id == id);
        }

       /* private string UploadedFile_I(HomeImageView model)
        {
            string uniqueFileName = null;

            if (model.Slide1 != null)
            {
                string uploadsFolder = Path.Combine(IWebHostEnvironment.WebRootPath, "images");
                //  uniqueFileName = Guid.NewGuid().ToString() + "_" + model.CarImage.FileName;
                uniqueFileName = "slide1" ;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Slide1.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }*/
    }
}
