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
    public class SuppliersController : Controller
    {
        private readonly Motorcycle_Dealership_DB_Final2Context _context;

        public SuppliersController(Motorcycle_Dealership_DB_Final2Context context)
        {
            _context = context;
        }

        // GET: Suppliers
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["FirstNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "firstname_desc" : "firstname";
            ViewData["LastNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "lastname_desc" : "lastname";

            var suppliers = from s in _context.Supplier
                            select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                suppliers = suppliers.Where(s => s.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "firstname_desc":
                    suppliers = suppliers.OrderByDescending(s => s.FirstName);
                    break;
                case "lastname":
                    suppliers = suppliers.OrderBy(s => s.LastName);
                    break;
                case "lastname_desc":
                    suppliers = suppliers.OrderByDescending(s => s.LastName);
                    break;
                default:
                    suppliers = suppliers.OrderBy(s => s.FirstName);
                    break;

            }
            //this is the pagination page size, so there will be 5 datas on each page//
            int pageSize = 5;
            return View(await PaginatedList<Supplier>.CreateAsync(suppliers.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Suppliers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier
                .Include(s => s.Inventory)
                .Include(s => s.Location)
                .FirstOrDefaultAsync(m => m.SupplierID == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // GET: Suppliers/Create
        public IActionResult Create()
        {
            ViewData["InventoryID"] = new SelectList(_context.Inventory, "InventoryID", "InventoryID");
            ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "LocationID");
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierID,LocationID,InventoryID,FirstName,LastName,PhoneNumber,Email,City,Address,Zip")] Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(supplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InventoryID"] = new SelectList(_context.Inventory, "InventoryID", "InventoryID", supplier.InventoryID);
            ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "LocationID", supplier.LocationID);
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            ViewData["InventoryID"] = new SelectList(_context.Inventory, "InventoryID", "InventoryID", supplier.InventoryID);
            ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "LocationID", supplier.LocationID);
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierID,LocationID,InventoryID,FirstName,LastName,PhoneNumber,Email,City,Address,Zip")] Supplier supplier)
        {
            if (id != supplier.SupplierID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierExists(supplier.SupplierID))
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
            ViewData["InventoryID"] = new SelectList(_context.Inventory, "InventoryID", "InventoryID", supplier.InventoryID);
            ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "LocationID", supplier.LocationID);
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier
                .Include(s => s.Inventory)
                .Include(s => s.Location)
                .FirstOrDefaultAsync(m => m.SupplierID == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplier = await _context.Supplier.FindAsync(id);
            if (supplier != null)
            {
                _context.Supplier.Remove(supplier);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierExists(int id)
        {
            return _context.Supplier.Any(e => e.SupplierID == id);
        }
    }
}
