using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Medicina.Models;

namespace Medicina.Controllers
{
    public class IdentificacionsController : Controller
    {
        private readonly EasyMedicineContext _context;

        public IdentificacionsController(EasyMedicineContext context)
        {
            _context = context;
        }

        // GET: Identificacions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Identificacions.ToListAsync());
        }

        // GET: Identificacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identificacions = await _context.Identificacions
                .SingleOrDefaultAsync(m => m.IdentificacionId == id);
            if (identificacions == null)
            {
                return NotFound();
            }

            return View(identificacions);
        }

        // GET: Identificacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Identificacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdentificacionId,TipoIdentificacion")] Identificacions identificacions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(identificacions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(identificacions);
        }

        // GET: Identificacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identificacions = await _context.Identificacions.SingleOrDefaultAsync(m => m.IdentificacionId == id);
            if (identificacions == null)
            {
                return NotFound();
            }
            return View(identificacions);
        }

        // POST: Identificacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdentificacionId,TipoIdentificacion")] Identificacions identificacions)
        {
            if (id != identificacions.IdentificacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(identificacions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdentificacionsExists(identificacions.IdentificacionId))
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
            return View(identificacions);
        }

        // GET: Identificacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identificacions = await _context.Identificacions
                .SingleOrDefaultAsync(m => m.IdentificacionId == id);
            if (identificacions == null)
            {
                return NotFound();
            }

            return View(identificacions);
        }

        // POST: Identificacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var identificacions = await _context.Identificacions.SingleOrDefaultAsync(m => m.IdentificacionId == id);
            _context.Identificacions.Remove(identificacions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdentificacionsExists(int id)
        {
            return _context.Identificacions.Any(e => e.IdentificacionId == id);
        }
    }
}
