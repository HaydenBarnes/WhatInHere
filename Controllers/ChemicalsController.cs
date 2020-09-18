using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhatInHere.Data;
using WhatInHere.Models;

namespace WhatInHere.Controllers
{
    public class ChemicalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChemicalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Chemicals
        public async Task<IActionResult> Index(string naturalChemical, string searchString)
        {
            IQueryable<string> naturalQuery = from m in _context.Chemicals
                                            orderby m.Natural
                                            select m.Natural;

            var chemicals = from m in _context.Chemicals
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                chemicals = chemicals.Where(s => s.Chemical.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(naturalChemical))
            {
                chemicals = chemicals.Where(x => x.Natural == naturalChemical);
            }

            var chemicalsNatualVM = new NaturalChemicalViewModel
            {
                Natural = new SelectList(await naturalQuery.Distinct().ToListAsync()),
                Chemicals = await chemicals.ToListAsync()
            };

            return View(chemicalsNatualVM);
        }

        // GET: Chemicals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chemicals = await _context.Chemicals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chemicals == null)
            {
                return NotFound();
            }

            return View(chemicals);
        }

        // GET: Chemicals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chemicals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Chemical,Effects,Natural,Source")] Chemicals chemicals)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chemicals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chemicals);
        }

        // GET: Chemicals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chemicals = await _context.Chemicals.FindAsync(id);
            if (chemicals == null)
            {
                return NotFound();
            }
            return View(chemicals);
        }

        // POST: Chemicals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Chemical,Effects,Natural,Source")] Chemicals chemicals)
        {
            if (id != chemicals.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chemicals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChemicalsExists(chemicals.Id))
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
            return View(chemicals);
        }

        // GET: Chemicals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chemicals = await _context.Chemicals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chemicals == null)
            {
                return NotFound();
            }

            return View(chemicals);
        }

        // POST: Chemicals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chemicals = await _context.Chemicals.FindAsync(id);
            _context.Chemicals.Remove(chemicals);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChemicalsExists(int id)
        {
            return _context.Chemicals.Any(e => e.Id == id);
        }
    }
}
