using System;
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
    public class InventoriesController : Controller
    {
        private readonly Motorcycle_Dealership_DB_Final2Context _context;

        public InventoriesController(Motorcycle_Dealership_DB_Final2Context context)
        {
            _context = context;
        }

        // GET: Inventories
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["ModelSortParm"] = String.IsNullOrEmpty(sortOrder) ? "model_desc" : "model";
            ViewData["PhoneNumberSortParm"] = String.IsNullOrEmpty(sortOrder) ? "phonenumber_desc" : "phonenumber";

            var inventories = from i in _context.Inventory
                            select i;


            if (!string.IsNullOrEmpty(searchString))
            {
                inventories = inventories.Where(s => s.Model.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "model_desc":
                    inventories = inventories.OrderByDescending(s => s.Model);
                    break;
                case "phonenumber":
                    inventories = inventories.OrderBy(s => s.PhoneNumber);
                    break;
                case "phonenumber_desc":
                    inventories = inventories.OrderByDescending(s => s.PhoneNumber);
                    break;
                default:
                    inventories = inventories.OrderBy(s => s.Model);
                    break;

            }

            return View(await inventories.ToListAsync());
          
        }

        // GET: Inventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory
                .Include(i => i.motorcycle)
                .FirstOrDefaultAsync(m => m.InventoryID == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // GET: Inventories/Create
        public IActionResult Create()
        {
            ViewData["MotorcycleID"] = new SelectList(_context.Set<Motorcycle>(), "MotorcycleID", "MotorcycleID");
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InventoryID,MotorcycleID,Model,PhoneNumber,Email,Function")] Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(inventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MotorcycleID"] = new SelectList(_context.Set<Motorcycle>(), "MotorcycleID", "MotorcycleID", inventory.MotorcycleID);
            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            ViewData["MotorcycleID"] = new SelectList(_context.Set<Motorcycle>(), "MotorcycleID", "MotorcycleID", inventory.MotorcycleID);
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InventoryID,MotorcycleID,Model,PhoneNumber,Email,Function")] Inventory inventory)
        {
            if (id != inventory.InventoryID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryExists(inventory.InventoryID))
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
            ViewData["MotorcycleID"] = new SelectList(_context.Set<Motorcycle>(), "MotorcycleID", "MotorcycleID", inventory.MotorcycleID);
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory
                .Include(i => i.motorcycle)
                .FirstOrDefaultAsync(m => m.InventoryID == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventory = await _context.Inventory.FindAsync(id);
            if (inventory != null)
            {
                _context.Inventory.Remove(inventory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventory.Any(e => e.InventoryID == id);
        }
    }
}
