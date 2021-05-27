using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EKomplet.Data;
using EKomplet.Models;

namespace EKomplet.Controllers
{
    public class BusinessController : Controller
    {
        private readonly DistrictDBContext _context;

        public BusinessController(DistrictDBContext context)
        {
            _context = context;
        }

        // GET: Business
        public async Task<IActionResult> Index()
        {
            var districtDBContext = _context.Businesses.Include(b => b.District);
            return View(await districtDBContext.ToListAsync());
        }

        // GET: Business/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var business = await _context.Businesses
                .Include(b => b.District)
                .FirstOrDefaultAsync(m => m.BusinessID == id);
            if (business == null) return NotFound();

            return View(business);
        }

        // GET: Business/Create
        public IActionResult Create()
        {
            ViewData["DistrictID"] = new SelectList(_context.Districts, "DistrictID", "DistrictName", "DistrictID");
            return View();
        }

        // POST: Business/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusinessID,BusinessName,DistrictID,Adress,ZipCode")]
            Business business)
        {
            if (ModelState.IsValid)
            {
                _context.Add(business);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["DistrictID"] =
                new SelectList(_context.Districts, "DistrictID", "DistrictName", business.DistrictID);
            return View(business);
        }

        // GET: Business/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var business = await _context.Businesses.FindAsync(id);
            if (business == null) return NotFound();
            ViewData["DistrictID"] =
                new SelectList(_context.Districts, "DistrictID", "DistrictName", business.DistrictID);
            return View(business);
        }

        // POST: Business/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BusinessID,BusinessName,DistrictID,Adress,ZipCode")]
            Business business)
        {
            if (id != business.BusinessID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(business);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessExists(business.BusinessID))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["DistrictID"] =
                new SelectList(_context.Districts, "DistrictID", "DistrictName", business.DistrictID);
            return View(business);
        }

        // GET: Business/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var business = await _context.Businesses
                .Include(b => b.District)
                .FirstOrDefaultAsync(m => m.BusinessID == id);
            if (business == null) return NotFound();

            return View(business);
        }

        // POST: Business/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var business = await _context.Businesses.FindAsync(id);
            _context.Businesses.Remove(business);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessExists(int id)
        {
            return _context.Businesses.Any(e => e.BusinessID == id);
        }
    }
}