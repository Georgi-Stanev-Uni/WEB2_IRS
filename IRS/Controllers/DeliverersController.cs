using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IRS.Data;
using IRS.Models;

namespace IRS.Controllers
{
    public class DeliverersController : Controller
    {
        private readonly IRSDbContext _context;

        public DeliverersController(IRSDbContext context)
        {
            _context = context;
        }

        // GET: Deliverers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Deliverers.ToListAsync());
        }

        // GET: Deliverers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliverer = await _context.Deliverers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (deliverer == null)
            {
                return NotFound();
            }

            return View(deliverer);
        }

        // GET: Deliverers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deliverers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Deliverer deliverer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deliverer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deliverer);
        }

        // GET: Deliverers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliverer = await _context.Deliverers.FindAsync(id);
            if (deliverer == null)
            {
                return NotFound();
            }
            return View(deliverer);
        }

        // POST: Deliverers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Name")] Deliverer deliverer)
        {
            if (id != deliverer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliverer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DelivererExists(deliverer.ID))
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
            return View(deliverer);
        }

        // GET: Deliverers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliverer = await _context.Deliverers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (deliverer == null)
            {
                return NotFound();
            }

            return View(deliverer);
        }

        // POST: Deliverers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var deliverer = await _context.Deliverers.FindAsync(id);
            if (deliverer != null)
            {
                _context.Deliverers.Remove(deliverer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DelivererExists(string id)
        {
            return _context.Deliverers.Any(e => e.ID == id);
        }
    }
}
