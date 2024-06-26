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
    public class LocationsController : Controller
    {
        private readonly Motorcycle_Dealership_DB_Final2Context _context;

        public LocationsController(Motorcycle_Dealership_DB_Final2Context context)
        {
            _context = context;
        }

        // GET: Locations
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["AddressSortParm"] = String.IsNullOrEmpty(sortOrder) ? "address_desc" : "address";
            ViewData["CitySortParm"] = String.IsNullOrEmpty(sortOrder) ? "city_desc" : "city";

            var locations = from l in _context.Location
                            select l;

            if (!string.IsNullOrEmpty(searchString))
            {
                locations = locations.Where(s => s.Country.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "address_desc":
                    locations = locations.OrderByDescending(s => s.Address);
                    break;
                case "city":
                    locations = locations.OrderBy(s => s.City);
                    break;
                case "city_desc":
                    locations = locations.OrderByDescending(s => s.City);
                    break;
                default:
                    locations = locations.OrderBy(s => s.Address);
                    break;

            }
            //this is the pagination page size, so there will be 5 datas on each page//
            int pageSize = 5;
            return View(await PaginatedList<Location>.CreateAsync(locations.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Location
                .FirstOrDefaultAsync(m => m.LocationID == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationID,Country,City,Address,Zip,PhoneNumber")] Location location)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(location);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        // GET: Locations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Location.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            return View(location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationID,Country,City,Address,Zip,PhoneNumber")] Location location)
        {
            if (id != location.LocationID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(location);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationExists(location.LocationID))
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
            return View(location);
        }

        // GET: Locations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Location
                .FirstOrDefaultAsync(m => m.LocationID == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var location = await _context.Location.FindAsync(id);
            if (location != null)
            {
                _context.Location.Remove(location);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationExists(int id)
        {
            return _context.Location.Any(e => e.LocationID == id);
        }
    }
}
