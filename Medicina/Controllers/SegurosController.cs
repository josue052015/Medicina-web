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
    public class SegurosController : Controller
    {
        private readonly EasyMedicineContext _context;

        public SegurosController(EasyMedicineContext context)
        {
            _context = context;
        }

        // GET: Seguros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Seguros.ToListAsync());
        }

        // GET: Seguros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seguros = await _context.Seguros
                .SingleOrDefaultAsync(m => m.TipoSeguroId == id);
            if (seguros == null)
            {
                return NotFound();
            }

            return View(seguros);
        }

        // GET: Seguros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Seguros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoSeguroId,Seguro1")] Seguros seguros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seguros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seguros);
        }

        // GET: Seguros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seguros = await _context.Seguros.SingleOrDefaultAsync(m => m.TipoSeguroId == id);
            if (seguros == null)
            {
                return NotFound();
            }
            return View(seguros);
        }

        // POST: Seguros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoSeguroId,Seguro1")] Seguros seguros)
        {
            if (id != seguros.TipoSeguroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seguros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SegurosExists(seguros.TipoSeguroId))
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
            return View(seguros);
        }

        // GET: Seguros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seguros = await _context.Seguros
                .SingleOrDefaultAsync(m => m.TipoSeguroId == id);
            if (seguros == null)
            {
                return NotFound();
            }

            return View(seguros);
        }

        // POST: Seguros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seguros = await _context.Seguros.SingleOrDefaultAsync(m => m.TipoSeguroId == id);
            _context.Seguros.Remove(seguros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SegurosExists(int id)
        {
            return _context.Seguros.Any(e => e.TipoSeguroId == id);
        }
    }
}
