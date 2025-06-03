using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCChair.Models;
using MvcChair.Data;

namespace MvcChair.Controllers
{
    public class ChairsController : Controller
    {
        private readonly MvcChairContext _context;

        public ChairsController(MvcChairContext context)
        {
            _context = context;
        }

        // GET: Chairs
        // GET: Chairs
        public async Task<IActionResult> Index(string chairType, string searchString)
        {
            if (_context.Chair == null)
            {
                return Problem("Entity set 'MVCChairContext.Chair' is null.");
            }

            // LINQ query to get distinct chair types (like genres)
            IQueryable<string> typeQuery = from c in _context.Chair
                                           orderby c.Type
                                           select c.Type;

            // Start with all chairs
            var chairs = from c in _context.Chair
                         select c;

            // Filter by brand if searchString is entered
            if (!string.IsNullOrEmpty(searchString))
            {
                chairs = chairs.Where(s => s.Brand!.ToUpper().Contains(searchString.ToUpper()));
            }

            // Filter by type if selected
            if (!string.IsNullOrEmpty(chairType))
            {
                chairs = chairs.Where(x => x.Type == chairType);
            }

            var chairTypeVM = new ChairTypeViewModel
            {
                Types = new SelectList(await typeQuery.Distinct().ToListAsync()),
                Chairs = await chairs.ToListAsync()
            };

            return View(chairTypeVM);
        }


        // GET: Chairs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chair = await _context.Chair
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chair == null)
            {
                return NotFound();
            }

            return View(chair);
        }

        // GET: Chairs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chairs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Type,Color,Material,Capacity,Price,Rating")] Chair chair)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chair);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chair);
        }

        // GET: Chairs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chair = await _context.Chair.FindAsync(id);
            if (chair == null)
            {
                return NotFound();
            }
            return View(chair);
        }

        // POST: Chairs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Type,Color,Material,Capacity,Price,Rating")] Chair chair)
        {
            if (id != chair.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chair);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChairExists(chair.Id))
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
            return View(chair);
        }

        // GET: Chairs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chair = await _context.Chair
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chair == null)
            {
                return NotFound();
            }

            return View(chair);
        }

        // POST: Chairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chair = await _context.Chair.FindAsync(id);
            if (chair != null)
            {
                _context.Chair.Remove(chair);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChairExists(int id)
        {
            return _context.Chair.Any(e => e.Id == id);
        }
    }
}
