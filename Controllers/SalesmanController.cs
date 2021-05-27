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
    public class SalesmanController : Controller
    {
        private readonly DistrictDBContext _context;

        public SalesmanController(DistrictDBContext context)
        {
            _context = context;
        }

        // GET: Salesman
        public async Task<IActionResult> Index()
        {
            return View(await _context.Salesmen.ToListAsync());
        }

        // GET: Salesman/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var salesman = await _context.Salesmen
                .FirstOrDefaultAsync(m => m.SalesmanID == id);
            if (salesman == null) return NotFound();

            return View(salesman);
        }

        // GET: Salesman/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salesman/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalesmanID,PhoneNumber,Email,FirstName,LastName")]
            Salesman salesman)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(salesman);
        }

        // GET: Salesman/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var salesman = await _context.Salesmen.FindAsync(id);
            if (salesman == null) return NotFound();
            return View(salesman);
        }

        // POST: Salesman/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalesmanID,PhoneNumber,Email,FirstName,LastName")]
            Salesman salesman)
        {
            if (id != salesman.SalesmanID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesmanExists(salesman.SalesmanID))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(salesman);
        }

        // GET: Salesman/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var salesman = await _context.Salesmen
                .FirstOrDefaultAsync(m => m.SalesmanID == id);
            if (salesman == null) return NotFound();

            return View(salesman);
        }

        // POST: Salesman/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesman = await _context.Salesmen.FindAsync(id);
            _context.Salesmen.Remove(salesman);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesmanExists(int id)
        {
            return _context.Salesmen.Any(e => e.SalesmanID == id);
        }
    }
}