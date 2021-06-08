
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Broker.Models;
using Broker.ViewModels;

namespace Broker.Controllers
{
    public class AssociatesController : Controller
    {
        private readonly MortgageBrokerDbContext _context;

        public AssociatesController(MortgageBrokerDbContext context)
        {
            _context = context;
        }

        // GET: Associates
        public async Task<IActionResult> Index()
        {
           


            AssociateProductViewModel viewModel = new AssociateProductViewModel()
            {
                Products= await _context.Products.ToListAsync(),
                Associates = await _context.Associates.ToListAsync(),
                CommissionsPaidProducts=await _context.CommissionsPaidProducts.ToListAsync(),



        };
            return View(viewModel);
        }

        // GET: Associates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associate = await _context.Associates
                .FirstOrDefaultAsync(m => m.AssociateId == id);
            if (associate == null)
            {
                return NotFound();
            }

            return View(associate);
        }

        // GET: Associates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Associates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssociateId,AssociateFirstName,AssociateLastName,Company,DateOfPayment,SplitId")] Associate associate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(associate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(associate);
        }

        // GET: Associates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associate = await _context.Associates.FindAsync(id);
            if (associate == null)
            {
                return NotFound();
            }
            return View(associate);
        }

        // POST: Associates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssociateId,AssociateFirstName,AssociateLastName,Company,DateOfPayment,SplitId")] Associate associate)
        {
            if (id != associate.AssociateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(associate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssociateExists(associate.AssociateId))
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
            return View(associate);
        }

        // GET: Associates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associate = await _context.Associates
                .FirstOrDefaultAsync(m => m.AssociateId == id);
            if (associate == null)
            {
                return NotFound();
            }

            return View(associate);
        }

        // POST: Associates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var associate = await _context.Associates.FindAsync(id);
            _context.Associates.Remove(associate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssociateExists(int id)
        {
            return _context.Associates.Any(e => e.AssociateId == id);
        }
    }
}
