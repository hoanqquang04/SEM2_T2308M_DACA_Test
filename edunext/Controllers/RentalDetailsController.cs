using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using edunext;
using edunext.Models;

namespace edunext.Controllers
{
    public class RentalDetailsController : Controller
    {
        private readonly EduDbContext _context;

        public RentalDetailsController(EduDbContext context)
        {
            _context = context;
        }

        // GET: RentalDetails
        public async Task<IActionResult> Index()
        {
            var eduDbContext = _context.RentalDetails.Include(r => r.ComicBook).Include(r => r.Rental);
            return View(await eduDbContext.ToListAsync());
        }

        // GET: RentalDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalDetail = await _context.RentalDetails
                .Include(r => r.ComicBook)
                .Include(r => r.Rental)
                .FirstOrDefaultAsync(m => m.RentalDetailID == id);
            if (rentalDetail == null)
            {
                return NotFound();
            }

            return View(rentalDetail);
        }

        // GET: RentalDetails/Create
        public IActionResult Create()
        {
            ViewData["ComicBookID"] = new SelectList(_context.ComicBooks, "ComicBookID", "Title");
            ViewData["RentalID"] = new SelectList(_context.Rentals, "RentalID", "RentalID");
            return View();
        }

        // POST: RentalDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentalDetailID,RentalID,ComicBookID,Quantity,PricePerDay")] RentalDetail rentalDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ComicBookID"] = new SelectList(_context.ComicBooks, "ComicBookID", "Title", rentalDetail.ComicBookID);
            ViewData["RentalID"] = new SelectList(_context.Rentals, "RentalID", "RentalID", rentalDetail.RentalID);
            return View(rentalDetail);
        }

        // GET: RentalDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalDetail = await _context.RentalDetails.FindAsync(id);
            if (rentalDetail == null)
            {
                return NotFound();
            }
            ViewData["ComicBookID"] = new SelectList(_context.ComicBooks, "ComicBookID", "Title", rentalDetail.ComicBookID);
            ViewData["RentalID"] = new SelectList(_context.Rentals, "RentalID", "RentalID", rentalDetail.RentalID);
            return View(rentalDetail);
        }

        // POST: RentalDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentalDetailID,RentalID,ComicBookID,Quantity,PricePerDay")] RentalDetail rentalDetail)
        {
            if (id != rentalDetail.RentalDetailID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalDetailExists(rentalDetail.RentalDetailID))
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
            ViewData["ComicBookID"] = new SelectList(_context.ComicBooks, "ComicBookID", "Title", rentalDetail.ComicBookID);
            ViewData["RentalID"] = new SelectList(_context.Rentals, "RentalID", "RentalID", rentalDetail.RentalID);
            return View(rentalDetail);
        }

        // GET: RentalDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalDetail = await _context.RentalDetails
                .Include(r => r.ComicBook)
                .Include(r => r.Rental)
                .FirstOrDefaultAsync(m => m.RentalDetailID == id);
            if (rentalDetail == null)
            {
                return NotFound();
            }

            return View(rentalDetail);
        }

        // POST: RentalDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalDetail = await _context.RentalDetails.FindAsync(id);
            if (rentalDetail != null)
            {
                _context.RentalDetails.Remove(rentalDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalDetailExists(int id)
        {
            return _context.RentalDetails.Any(e => e.RentalDetailID == id);
        }
    }
}
