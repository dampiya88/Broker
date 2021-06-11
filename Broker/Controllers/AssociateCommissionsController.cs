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
    public class AssociateCommissionsController : Controller
    {
        private readonly MortgageBrokerDbContext _context;

        public AssociateCommissionsController(MortgageBrokerDbContext context)
        {
            _context = context;
        }

        // GET: AssociateCommissions
        public async Task<IActionResult> Index()
        {
            var mortgageBrokerDbContext = _context.AssociateCommissions.Include(a => a.Associate);
            return View(await mortgageBrokerDbContext.ToListAsync());
        }

        // GET: AssociateCommissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associateCommission = await _context.AssociateCommissions
                .Include(a => a.Associate)
                .FirstOrDefaultAsync(m => m.AssociateCommissionId == id);
            if (associateCommission == null)
            {
                return NotFound();
            }

            return View(associateCommission);
        }

        // GET: AssociateCommissions/Create
        public IActionResult Create()
        {
            ViewData["AssociateId"] = new SelectList(_context.Associates, "AssociateId", "AssociateLastName");
            ViewData["CommissionSplitId"] = new SelectList(_context.CommissionSplits, "CommissionSplitId", "AssociateSplitPortion");
            return View();
        }

        // POST: AssociateCommissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssociateCommissionId,AssociateId,AssociateCommission1,EffectiveDate,CreatedDate,CreatedBy,LastUpdateDate,LastUpdatedBy,CommissionSplitId")] AssociateCommission associateCommission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(associateCommission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssociateId"] = new SelectList(_context.Associates, "AssociateId", "AssociateLastName", associateCommission.AssociateId);
            ViewData["CommissionSplitId"] = new SelectList(_context.CommissionSplits, "CommissionSplitId", "AssociateSplitPortion", associateCommission.CommissionSplitId);
            return View(associateCommission);
        }

        // GET: AssociateCommissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associateCommission = await _context.AssociateCommissions.FindAsync(id);
            if (associateCommission == null)
            {
                return NotFound();
            }
            ViewData["AssociateId"] = new SelectList(_context.Associates, "AssociateId", "AssociateFirstName", associateCommission.AssociateId);
            return View(associateCommission);
        }

        // POST: AssociateCommissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssociateCommissionId,AssociateId,AssociateCommission1,EffectiveDate,CreatedDate,CreatedBy,LastUpdateDate,LastUpdatedBy,CommissionSplitId")] AssociateCommission associateCommission)
        {
            if (id != associateCommission.AssociateCommissionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(associateCommission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssociateCommissionExists(associateCommission.AssociateCommissionId))
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
            ViewData["AssociateId"] = new SelectList(_context.Associates, "AssociateId", "AssociateFirstName", associateCommission.AssociateId);
            return View(associateCommission);
        }

        // GET: AssociateCommissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associateCommission = await _context.AssociateCommissions
                .Include(a => a.Associate)
                .FirstOrDefaultAsync(m => m.AssociateCommissionId == id);
            if (associateCommission == null)
            {
                return NotFound();
            }

            return View(associateCommission);
        }

        // POST: AssociateCommissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var associateCommission = await _context.AssociateCommissions.FindAsync(id);
            _context.AssociateCommissions.Remove(associateCommission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssociateCommissionExists(int id)
        {
            return _context.AssociateCommissions.Any(e => e.AssociateCommissionId == id);
        }
    }
}
