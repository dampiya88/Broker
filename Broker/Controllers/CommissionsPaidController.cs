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
    public class CommissionsPaidController : Controller
    {
        private readonly MortgageBrokerDbContext _context;

        public CommissionsPaidController(MortgageBrokerDbContext context)
        {
            _context = context;
        }

        // GET: CommissionsPaid
        public async Task<IActionResult> Index()
        {
            return View(await _context.CommissionsPaids.ToListAsync());
        }

        // GET: CommissionsPaid/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commissionsPaid = await _context.CommissionsPaids
                .FirstOrDefaultAsync(m => m.CommissionsPaidId == id);
            if (commissionsPaid == null)
            {
                return NotFound();
            }

            return View(commissionsPaid);
        }

        // GET: CommissionsPaid/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CommissionsPaid/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommissionsPaidId,DatePaid,CommissionType,PaymentType,ChequeNumber,CreatedDate,CreatedBy,LastUpdateDate,LastUpdatedBy")] CommissionsPaid commissionsPaid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commissionsPaid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(commissionsPaid);
        }

        // GET: CommissionsPaid/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commissionsPaid = await _context.CommissionsPaids.FindAsync(id);
            if (commissionsPaid == null)
            {
                return NotFound();
            }
            return View(commissionsPaid);
        }

        // POST: CommissionsPaid/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommissionsPaidId,DatePaid,CommissionType,PaymentType,ChequeNumber,CreatedDate,CreatedBy,LastUpdateDate,LastUpdatedBy")] CommissionsPaid commissionsPaid)
        {
            if (id != commissionsPaid.CommissionsPaidId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commissionsPaid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommissionsPaidExists(commissionsPaid.CommissionsPaidId))
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
            return View(commissionsPaid);
        }

        // GET: CommissionsPaid/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commissionsPaid = await _context.CommissionsPaids
                .FirstOrDefaultAsync(m => m.CommissionsPaidId == id);
            if (commissionsPaid == null)
            {
                return NotFound();
            }

            return View(commissionsPaid);
        }

        // POST: CommissionsPaid/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commissionsPaid = await _context.CommissionsPaids.FindAsync(id);
            _context.CommissionsPaids.Remove(commissionsPaid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommissionsPaidExists(int id)
        {
            return _context.CommissionsPaids.Any(e => e.CommissionsPaidId == id);
        }
    }
}
