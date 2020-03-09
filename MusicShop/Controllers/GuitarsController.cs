using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicShop.Data;
using MusicShop.Models;
using MusicShop.ViewModels;

namespace MusicShop.Controllers
{
    [Authorize]
    public class GuitarsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        [Obsolete]
        public GuitarsController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: Guitars
        public async Task<IActionResult> Index()
        {
            return View(await _context.Guitar.ToListAsync());
        }

        public async Task<IActionResult> CustomerSearch(string searchString)
        {
            var guitars = from g in _context.Guitar select g;

            if (!String.IsNullOrEmpty(searchString))
            {
                guitars = guitars.Where(s => s.Brand.Contains(searchString) |
                                             s.ModelName.Contains(searchString));
            }

            return View(await guitars.ToListAsync());
        }

        public async Task<IActionResult> CustomerDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guitar = await _context.Guitar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guitar == null)
            {
                return NotFound();
            }

            return View(guitar);
        }

        // GET: Guitars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guitar = await _context.Guitar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guitar == null)
            {
                return NotFound();
            }

            return View(guitar);
        }

        // GET: Guitars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guitars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> Create(GuitarCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Image != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Guitar guitar = new Guitar
                {
                    Brand = model.Brand,
                    ModelName = model.ModelName,
                    NumOfStrings = model.NumOfStrings,
                    Description = model.Description,
                    Price = model.Price,
                    ImagePath = uniqueFileName
                };

                _context.Add(guitar);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id = guitar.Id });
            }
            return View();
        }

        // GET: Guitars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guitar = await _context.Guitar.FindAsync(id);
            if (guitar == null)
            {
                return NotFound();
            }
            return View(guitar);
        }

        // POST: Guitars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,ModelName,NumOfStrings,Description,Price")] Guitar guitar)
        {
            if (id != guitar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guitar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuitarExists(guitar.Id))
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
            return View(guitar);
        }

        // GET: Guitars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guitar = await _context.Guitar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guitar == null)
            {
                return NotFound();
            }

            return View(guitar);
        }

        // POST: Guitars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guitar = await _context.Guitar.FindAsync(id);
            _context.Guitar.Remove(guitar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuitarExists(int id)
        {
            return _context.Guitar.Any(e => e.Id == id);
        }
    }
}
