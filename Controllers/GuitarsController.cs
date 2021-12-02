using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcGuitars10.Data;
using MvcGuitars10.Models;

namespace MvcGuitars10.Controllers
{
    public class GuitarsController : Controller
    {
        private readonly MvcGuitars10Context _context;

        public GuitarsController(MvcGuitars10Context context)
        {
            _context = context;
        }

        // GET: Guitars
        public async Task<IActionResult> Index()
        {
            return View(await _context.Guitars.ToListAsync());
        }

        // GET: Guitars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guitars = await _context.Guitars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guitars == null)
            {
                return NotFound();
            }

            return View(guitars);
        }

        // GET: Guitars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guitars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GuitarModel,GuitarBrand,IssueYear,Price")] Guitars guitars)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guitars);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guitars);
        }

        // GET: Guitars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guitars = await _context.Guitars.FindAsync(id);
            if (guitars == null)
            {
                return NotFound();
            }
            return View(guitars);
        }

        // POST: Guitars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GuitarModel,GuitarBrand,IssueYear,Price")] Guitars guitars)
        {
            if (id != guitars.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guitars);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuitarsExists(guitars.Id))
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
            return View(guitars);
        }

        // GET: Guitars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guitars = await _context.Guitars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guitars == null)
            {
                return NotFound();
            }

            return View(guitars);
        }

        // POST: Guitars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guitars = await _context.Guitars.FindAsync(id);
            _context.Guitars.Remove(guitars);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuitarsExists(int id)
        {
            return _context.Guitars.Any(e => e.Id == id);
        }
    }
}
