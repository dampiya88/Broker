using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Broker.Models;

namespace Broker.Controllers
{
    public class CommissionsPaidProductsController : Controller
    {
        private readonly MortgageBrokerDbContext _context;

        public CommissionsPaidProductsController(MortgageBrokerDbContext context)
        {
            _context = context;
        }

        // GET: CommissionsPaidProducts
        public async Task<IActionResult> Index()
        {
            var mortgageBrokerDbContext = _context.CommissionsPaidProducts.Include(c => c.CommissionsPaid).Include(c => c.Product);
            return View(await mortgageBrokerDbContext.ToListAsync());
        }

        // GET: CommissionsPaidProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commissionsPaidProduct = await _context.CommissionsPaidProducts
                .Include(c => c.CommissionsPaid)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.CommissionsPaidProductId == id);
            if (commissionsPaidProduct == null)
            {
                return NotFound();
            }

            return View(commissionsPaidProduct);
        }

        // GET: CommissionsPaidProducts/Create
        public IActionResult Create()
        {
            ViewData["CommissionsPaidId"] = new SelectList(_context.CommissionsPaids, "CommissionsPaidId", "CommissionsPaidId");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
            return View();
        }

        // POST: CommissionsPaidProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommissionsPaidProductId,CommissionsPaidId,ProductId,Commission,CreatedDate,CreatedBy,LastUpdateDate,LastUpdatedBy,AssociateId, AssociateFirstName, AssociateLastName, Company, DateOfPayment, SplitId")] CommissionsPaidProduct commissionsPaidProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commissionsPaidProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CommissionsPaidId"] = new SelectList(_context.CommissionsPaids, "CommissionsPaidId", "CommissionsPaidId", commissionsPaidProduct.CommissionsPaidId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", commissionsPaidProduct.ProductId);
            ViewData["AssociateId"] = new SelectList(_context.Associates, "AssociateId", "ProductId", commissionsPaidProduct.ProductId);
            return View(commissionsPaidProduct);
        }

        // GET: CommissionsPaidProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commissionsPaidProduct = await _context.CommissionsPaidProducts.FindAsync(id);
            if (commissionsPaidProduct == null)
            {
                return NotFound();
            }
            ViewData["CommissionsPaidId"] = new SelectList(_context.CommissionsPaids, "CommissionsPaidId", "CommissionsPaidId", commissionsPaidProduct.CommissionsPaidId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", commissionsPaidProduct.ProductId);
            return View(commissionsPaidProduct);
        }

        // POST: CommissionsPaidProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommissionsPaidProductId,CommissionsPaidId,ProductId,Commission,CreatedDate,CreatedBy,LastUpdateDate,LastUpdatedBy")] CommissionsPaidProduct commissionsPaidProduct)
        {
            if (id != commissionsPaidProduct.CommissionsPaidProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commissionsPaidProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommissionsPaidProductExists(commissionsPaidProduct.CommissionsPaidProductId))
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
            ViewData["CommissionsPaidId"] = new SelectList(_context.CommissionsPaids, "CommissionsPaidId", "CommissionsPaidId", commissionsPaidProduct.CommissionsPaidId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", commissionsPaidProduct.ProductId);
            return View(commissionsPaidProduct);
        }

        // GET: CommissionsPaidProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commissionsPaidProduct = await _context.CommissionsPaidProducts
                .Include(c => c.CommissionsPaid)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.CommissionsPaidProductId == id);
            if (commissionsPaidProduct == null)
            {
                return NotFound();
            }

            return View(commissionsPaidProduct);
        }

        // POST: CommissionsPaidProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commissionsPaidProduct = await _context.CommissionsPaidProducts.FindAsync(id);
            _context.CommissionsPaidProducts.Remove(commissionsPaidProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommissionsPaidProductExists(int id)
        {
            return _context.CommissionsPaidProducts.Any(e => e.CommissionsPaidProductId == id);
        }
    }
}
