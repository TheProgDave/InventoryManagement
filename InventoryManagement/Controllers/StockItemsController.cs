using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Data;
using InventoryManagement.Models;

namespace InventoryManagement.Controllers
{
    public class StockItemsController : Controller
    {
        private readonly InventoryManagementContext _db;

        public StockItemsController(InventoryManagementContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            if (_db.StockItems == null)
            {
                return Problem("Entity set 'InventoryManagementContext.StockItems'  is null.");
            }

            var stockItems = from m in _db.StockItems
                             select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                stockItems = stockItems.Where(s => s.Description!.Contains(searchString) || s.ProductId.ToString() == searchString);
            }

            return View(await stockItems.ToListAsync());
        }

        // GET: StockItems/Details/ProductId
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockItem = await _db.StockItems
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (stockItem == null)
            {
                return NotFound();
            }

            return View(stockItem);
        }

        // GET: StockItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StockItems/Create/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Description,StockAmount,SafeStockAmount,Price")] StockItem stockItem)
        {
            if (ModelState.IsValid)
            {
                _db.Add(stockItem);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stockItem);
        }

        // GET: StockItems/Edit/ProductId
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockItem = await _db.StockItems.FindAsync(id);
            if (stockItem == null)
            {
                return NotFound();
            }
            return View(stockItem);
        }

        // POST: StockItems/Edit/ProductId/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Description,StockAmount,SafeStockAmount,Price")] StockItem stockItem)
        {
            if (id != stockItem.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(stockItem);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockItemExists(stockItem.ProductId))
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
            return View(stockItem);
        }

        // GET: StockItems/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockItem = await _db.StockItems
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (stockItem == null)
            {
                return NotFound();
            }

            return View(stockItem);
        }

        // POST: StockItems/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stockItem = await _db.StockItems.FindAsync(id);
            if (stockItem != null)
            {
                _db.StockItems.Remove(stockItem);
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockItemExists(int id)
        {
            return _db.StockItems.Any(e => e.ProductId == id);
        }
    }
}
