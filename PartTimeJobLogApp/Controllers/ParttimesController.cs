using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PartTimeJobLogApp.Data;
using PartTimeJobLogApp.Models;

namespace PartTimeJobLogApp.Controllers
{
    public class ParttimesController : Controller
    {
        private readonly PartTimeJobLogAppContext _context;

        public ParttimesController(PartTimeJobLogAppContext context)
        {
            _context = context;
        }

        // GET: Parttimes
        public async Task<IActionResult> Index()
        {
              return _context.Parttime != null ? 
                          View(await _context.Parttime.ToListAsync()) :
                          Problem("Entity set 'PartTimeJobLogAppContext.Parttime'  is null.");
        }

        // GET: Parttimes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Parttime == null)
            {
                return NotFound();
            }

            var parttime = await _context.Parttime
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parttime == null)
            {
                return NotFound();
            }

            return View(parttime);
        }

        // GET: Parttimes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parttimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Tel,Interview")] Parttime parttime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parttime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parttime);
        }

        // GET: Parttimes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Parttime == null)
            {
                return NotFound();
            }

            var parttime = await _context.Parttime.FindAsync(id);
            if (parttime == null)
            {
                return NotFound();
            }
            return View(parttime);
        }

        // POST: Parttimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Tel,Interview")] Parttime parttime)
        {
            if (id != parttime.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parttime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParttimeExists(parttime.Id))
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
            return View(parttime);
        }

        // GET: Parttimes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Parttime == null)
            {
                return NotFound();
            }

            var parttime = await _context.Parttime
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parttime == null)
            {
                return NotFound();
            }

            return View(parttime);
        }

        // POST: Parttimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Parttime == null)
            {
                return Problem("Entity set 'PartTimeJobLogAppContext.Parttime'  is null.");
            }
            var parttime = await _context.Parttime.FindAsync(id);
            if (parttime != null)
            {
                _context.Parttime.Remove(parttime);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParttimeExists(int id)
        {
          return (_context.Parttime?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
