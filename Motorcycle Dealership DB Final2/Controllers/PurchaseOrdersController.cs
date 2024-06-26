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
    public class PurchaseOrdersController : Controller
    {
        private readonly Motorcycle_Dealership_DB_Final2Context _context;

        public PurchaseOrdersController(Motorcycle_Dealership_DB_Final2Context context)
        {
            _context = context;
        }

        // GET: PurchaseOrders
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {

            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["ModelSortParm"] = String.IsNullOrEmpty(sortOrder) ? "model_desc" : "model";
            ViewData["ZipSortParm"] = String.IsNullOrEmpty(sortOrder) ? "zip_desc" : "zip";

            var purchaseorders = from p in _context.PurchaseOrder
                              select p;



            if (!string.IsNullOrEmpty(searchString))
            {
                purchaseorders = purchaseorders.Where(s => s.Model.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "model_desc":
                    purchaseorders = purchaseorders.OrderByDescending(s => s.Model);
                    break;
                case "zip":
                    purchaseorders = purchaseorders.OrderBy(s => s.Zip);
                    break;
                case "zip_desc":
                    purchaseorders = purchaseorders.OrderByDescending(s => s.Zip);
                    break;
                default:
                    purchaseorders = purchaseorders.OrderBy(s => s.Model);
                    break;

            }
            //this is the pagination page size, so there will be 5 datas on each page//
            int pageSize = 5;
            return View(await PaginatedList<PurchaseOrder>.CreateAsync(purchaseorders.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: PurchaseOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrder = await _context.PurchaseOrder
                .Include(p => p.customer)
                .FirstOrDefaultAsync(m => m.PurchaseOrderID == id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Create
        public IActionResult Create()
        {
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerID");
            return View();
        }

        // POST: PurchaseOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchaseOrderID,CustomerID,PurchaseDate,Model,Zip,PhoneNumber")] PurchaseOrder purchaseOrder)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(purchaseOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerID", purchaseOrder.CustomerID);
            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrder = await _context.PurchaseOrder.FindAsync(id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerID", purchaseOrder.CustomerID);
            return View(purchaseOrder);
        }

        // POST: PurchaseOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaseOrderID,CustomerID,PurchaseDate,Model,Zip,PhoneNumber")] PurchaseOrder purchaseOrder)
        {
            if (id != purchaseOrder.PurchaseOrderID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseOrderExists(purchaseOrder.PurchaseOrderID))
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
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerID", purchaseOrder.CustomerID);
            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrder = await _context.PurchaseOrder
                .Include(p => p.customer)
                .FirstOrDefaultAsync(m => m.PurchaseOrderID == id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return View(purchaseOrder);
        }

        // POST: PurchaseOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseOrder = await _context.PurchaseOrder.FindAsync(id);
            if (purchaseOrder != null)
            {
                _context.PurchaseOrder.Remove(purchaseOrder);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseOrderExists(int id)
        {
            return _context.PurchaseOrder.Any(e => e.PurchaseOrderID == id);
        }
    }
}
