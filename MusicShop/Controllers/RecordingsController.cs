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
    public class RecordingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecordingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recordings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recording.ToListAsync());
        }

        public async Task<IActionResult> CustomerSearch(string searchString)
        {
            var recordings = from r in _context.Recording select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                recordings = recordings.Where(s => s.Brand.Contains(searchString) |
                                         s.Model.Contains(searchString));
            }

            return View(await recordings.ToListAsync());
        }

        // GET: Recordings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recording = await _context.Recording
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recording == null)
            {
                return NotFound();
            }

            return View(recording);
        }

        // GET: Recordings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recordings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Model,Description,Price")] Recording recording)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recording);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recording);
        }

        // GET: Recordings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recording = await _context.Recording.FindAsync(id);
            if (recording == null)
            {
                return NotFound();
            }
            return View(recording);
        }

        // POST: Recordings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Model,Description,Price")] Recording recording)
        {
            if (id != recording.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recording);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecordingExists(recording.Id))
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
            return View(recording);
        }

        // GET: Recordings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recording = await _context.Recording
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recording == null)
            {
                return NotFound();
            }

            return View(recording);
        }

        // POST: Recordings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recording = await _context.Recording.FindAsync(id);
            _context.Recording.Remove(recording);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecordingExists(int id)
        {
            return _context.Recording.Any(e => e.Id == id);
        }
    }
}
