using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarSale.Data;
using CarSale.Models;
using Microsoft.AspNetCore.Authorization;

namespace CarSale.Controllers
{
    public class TestDrivesController : Controller
    {
        private readonly CarSaleDbContext _context;

        public TestDrivesController(CarSaleDbContext context)
        {
            _context = context;
        }

        // GET: TestDrives
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.TestDrive.ToListAsync());
        }

        // GET: TestDriveList
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> TestDriveList()
        {  
            return View(await _context.TestDrive.ToListAsync());
        }

        // GET: TestDrives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testDrive = await _context.TestDrive
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testDrive == null)
            {
                return NotFound();
            }

            return View(testDrive);
        }

        // POST: TestDrives/Create
        [Authorize(Roles = "Member")]
        public IActionResult Create( )
        {
            return View();
        }

        // POST: TestDrives/ApproveTestDrive
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveTestDrive(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testDrive = await _context.TestDrive
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testDrive == null)
            {
                return NotFound();
            }

            return View(testDrive);
        }
        // POST: TestDrives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,PhoneNumber,Date,StartTime,EndTime,Message")] TestDrive testDrive)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testDrive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testDrive);
        }

        // GET: TestDrives/SuggestToTestDrive/5
        public async Task<IActionResult> SuggestToTestDrive(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testDrive = await _context.TestDrive.FindAsync(id);
            if (testDrive == null)
            {
                return NotFound();
            }
            return View(testDrive);
        }

        // POST: TestDrives/SuggestToTestDrive/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SuggestToTestDrive(int id, [Bind("Id,FirstName,LastName,Email,PhoneNumber,Date,StartTime,EndTime,Message")] TestDrive testDrive)
        {
            if (id != testDrive.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testDrive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestDriveExists(testDrive.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(TestDriveList));
            }
            return View(testDrive);
        }
        // GET: TestDrives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testDrive = await _context.TestDrive.FindAsync(id);
            if (testDrive == null)
            {
                return NotFound();
            }
            return View(testDrive);
        }

        // POST: TestDrives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,PhoneNumber,Date,StartTime,EndTime,Message")] TestDrive testDrive)
        {
            if (id != testDrive.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testDrive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestDriveExists(testDrive.Id))
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
            return View(testDrive);
        }

        // GET: TestDrives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testDrive = await _context.TestDrive
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testDrive == null)
            {
                return NotFound();
            }

            return View(testDrive);
        }

        // POST: TestDrives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testDrive = await _context.TestDrive.FindAsync(id);
            _context.TestDrive.Remove(testDrive);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestDriveExists(int id)
        {
            return _context.TestDrive.Any(e => e.Id == id);
        }
    }
}
