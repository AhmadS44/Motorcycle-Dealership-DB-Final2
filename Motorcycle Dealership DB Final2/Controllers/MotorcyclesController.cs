﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Motorcycle_Dealership_DB_Final2.Areas.Identity.Data;
using Motorcycle_Dealership_DB_Final2.Models;

namespace Motorcycle_Dealership_DB_Final2.Controllers
{
    public class MotorcyclesController : Controller
    {
        private readonly Motorcycle_Dealership_DB_Final2Context _context;

        public MotorcyclesController(Motorcycle_Dealership_DB_Final2Context context)
        {
            _context = context;
        }

        // GET: Motorcycles
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["ModelSortParm"] = String.IsNullOrEmpty(sortOrder) ? "model_desc" : "model";
            ViewData["YearSortParm"] = String.IsNullOrEmpty(sortOrder) ? "year_desc" : "year";

            var motorcycles = from m in _context.Motorcycle
                            select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                motorcycles = motorcycles.Where(s => s.Model.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "model_desc":
                    motorcycles = motorcycles.OrderByDescending(s => s.Model);
                    break;
                case "year":
                    motorcycles = motorcycles.OrderBy(s => s.Year);
                    break;
                case "year_desc":
                    motorcycles = motorcycles.OrderByDescending(s => s.Year);
                    break;
                default:
                    motorcycles = motorcycles.OrderBy(s => s.Model);
                    break;

            }
            //this is the pagination page size, so there will be 5 datas on each page//
            int pageSize = 5;
            return View(await PaginatedList<Motorcycle>.CreateAsync(motorcycles.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        // GET: Motorcycles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorcycle = await _context.Motorcycle
                .FirstOrDefaultAsync(m => m.MotorcycleID == id);
            if (motorcycle == null)
            {
                return NotFound();
            }

            return View(motorcycle);
        }

        // GET: Motorcycles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Motorcycles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MotorcycleID,Model,Year,Weight,Colour")] Motorcycle motorcycle)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(motorcycle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(motorcycle);
        }

        // GET: Motorcycles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorcycle = await _context.Motorcycle.FindAsync(id);
            if (motorcycle == null)
            {
                return NotFound();
            }
            return View(motorcycle);
        }

        // POST: Motorcycles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MotorcycleID,Model,Year,Weight,Colour")] Motorcycle motorcycle)
        {
            if (id != motorcycle.MotorcycleID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(motorcycle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotorcycleExists(motorcycle.MotorcycleID))
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
            return View(motorcycle);
        }

        // GET: Motorcycles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorcycle = await _context.Motorcycle
                .FirstOrDefaultAsync(m => m.MotorcycleID == id);
            if (motorcycle == null)
            {
                return NotFound();
            }

            return View(motorcycle);
        }

        // POST: Motorcycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var motorcycle = await _context.Motorcycle.FindAsync(id);
            if (motorcycle != null)
            {
                _context.Motorcycle.Remove(motorcycle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotorcycleExists(int id)
        {
            return _context.Motorcycle.Any(e => e.MotorcycleID == id);
        }
    }
}
