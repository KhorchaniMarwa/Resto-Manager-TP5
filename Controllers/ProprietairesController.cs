using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestoManager_Marwa.Models.RestosModel;

namespace RestoManager_Marwa.Controllers
{
    public class ProprietairesController : Controller
    {
        private readonly RestosDbContext _context;

        public ProprietairesController(RestosDbContext context)
        {
            _context = context;
        }

        // GET: Proprietaires
        public async Task<IActionResult> Index()
        {
            return View(await _context.Proprietaires.ToListAsync());
        }

        // GET: Proprietaires/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietaire = await _context.Proprietaires
                .FirstOrDefaultAsync(m => m.Gsm == id);
            if (proprietaire == null)
            {
                return NotFound();
            }

            return View(proprietaire);
        }

        // GET: Proprietaires/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proprietaires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Gsm")] Proprietaire proprietaire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proprietaire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proprietaire);
        }

        // GET: Proprietaires/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietaire = await _context.Proprietaires.FindAsync(id);
            if (proprietaire == null)
            {
                return NotFound();
            }
            return View(proprietaire);
        }

        // POST: Proprietaires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Email,Gsm")] Proprietaire proprietaire)
        {
            if (id != proprietaire.Gsm)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proprietaire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProprietaireExists(proprietaire.Gsm))
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
            return View(proprietaire);
        }

        // GET: Proprietaires/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietaire = await _context.Proprietaires
                .FirstOrDefaultAsync(m => m.Gsm == id);
            if (proprietaire == null)
            {
                return NotFound();
            }

            return View(proprietaire);
        }

        // POST: Proprietaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var proprietaire = await _context.Proprietaires.FindAsync(id);
            if (proprietaire != null)
            {
                _context.Proprietaires.Remove(proprietaire);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProprietaireExists(string id)
        {
            return _context.Proprietaires.Any(e => e.Gsm == id);
        }
    }
}
