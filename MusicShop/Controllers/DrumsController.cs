using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicShop.Data;
using MusicShop.Models;

namespace MusicShop.Controllers
{
    [Authorize]
    public class DrumsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DrumsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Drums
        public async Task<IActionResult> Index()
        {
            return View(await _context.Drum.ToListAsync());
        }

        public async Task<IActionResult> CustomerSearch(string searchString)
        {
            var drums = from d in _context.Drum select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                drums = drums.Where(s => s.Brand.Contains(searchString) |
                                         s.PercussionModel.Contains(searchString));
            }

            return View(await drums.ToListAsync());
        }

        public async Task<IActionResult> CustomerDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drum = await _context.Drum
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drum == null)
            {
                return NotFound();
            }

            return View(drum);
        }

        // GET: Drums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drum = await _context.Drum
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drum == null)
            {
                return NotFound();
            }

            return View(drum);
        }

        public async Task<IActionResult> Cart(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drum = await _context.Drum
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drum == null)
            {
                return NotFound();
            }

            return View(drum);
        }

        // GET: Drums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Drums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,PercussionModel,Description,Price")] Drum drum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drum);
        }

        // GET: Drums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drum = await _context.Drum.FindAsync(id);
            if (drum == null)
            {
                return NotFound();
            }
            return View(drum);
        }

        // POST: Drums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,PercussionModel,Description,Price")] Drum drum)
        {
            if (id != drum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrumExists(drum.Id))
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
            return View(drum);
        }

        // GET: Drums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drum = await _context.Drum
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drum == null)
            {
                return NotFound();
            }

            return View(drum);
        }

        // POST: Drums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drum = await _context.Drum.FindAsync(id);
            _context.Drum.Remove(drum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrumExists(int id)
        {
            return _context.Drum.Any(e => e.Id == id);
        }
    }
}
