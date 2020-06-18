﻿using System;
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
    public class DistrictController : Controller
    {
        private readonly DistrictDBContext _context;

        public DistrictController(DistrictDBContext context)
        {
            _context = context;
        }

        // GET: District
        public async Task<IActionResult> Index()
        {
            return View(await _context.Districts.ToListAsync());
        }

        // GET: District/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var district = await _context.Districts
                .FirstOrDefaultAsync(m => m.DistrictName == id);
            if (district == null)
            {
                return NotFound();
            }

            return View(district);
        }

        // GET: District/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: District/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DistrictName,PrimarySalesman")] District district)
        {
            if (ModelState.IsValid)
            {
                _context.Add(district);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(district);
        }

        // GET: District/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var district = await _context.Districts.FindAsync(id);
            if (district == null)
            {
                return NotFound();
            }
            return View(district);
        }

        // POST: District/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DistrictName,PrimarySalesman")] District district)
        {
            if (id != district.DistrictName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(district);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DistrictExists(district.DistrictName))
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
            return View(district);
        }

        // GET: District/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var district = await _context.Districts
                .FirstOrDefaultAsync(m => m.DistrictName == id);
            if (district == null)
            {
                return NotFound();
            }

            return View(district);
        }

        // POST: District/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var district = await _context.Districts.FindAsync(id);
            _context.Districts.Remove(district);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DistrictExists(string id)
        {
            return _context.Districts.Any(e => e.DistrictName == id);
        }
    }
}
