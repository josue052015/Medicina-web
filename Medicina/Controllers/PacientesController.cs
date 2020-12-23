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
    public class PacientesController : Controller
    {
        private readonly EasyMedicineContext _context;


        public PacientesController(EasyMedicineContext context)
        {
            _context = context;
        }

        // GET: Pacientes
        public async Task<IActionResult> Index()
        {
            var easyMedicineContext = _context.Pacientes.Include(p => p.IdentificacionNavigation).Include(p => p.SexoNavigation).Include(p => p.TipoSeguroNavigation);
            return View(await easyMedicineContext.ToListAsync());
        }

        // GET: Pacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacientes = await _context.Pacientes
                .Include(p => p.IdentificacionNavigation)
                .Include(p => p.SexoNavigation)
                .Include(p => p.TipoSeguroNavigation)
                .SingleOrDefaultAsync(m => m.PacienteId == id);
            if (pacientes == null)
            {
                return NotFound();
            }

            return View(pacientes);
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
          ViewData["Identificacion"] = new SelectList(_context.Identificacions, "IdentificacionId", "TipoIdentificacion");
            ViewData["Sexo"] = new SelectList(_context.Sexos, "SexoId", "TipoSexo");
            ViewData["TipoSeguro"] = new SelectList(_context.Seguros, "TipoSeguroId", "Seguro1");
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PacienteId,Nombre,Apellido,Sexo,Identificacion,NumeroIdentificacion,TelefonoCasa,TelefonoCelular,FechaNacimiento,Edad,TipoSeguro,FechaPrimeraVez")] Pacientes pacientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Identificacion"] = new SelectList(_context.Identificacions, "IdentificacionId", "TipoIdentificacion", pacientes.Identificacion);
            ViewData["Sexo"] = new SelectList(_context.Sexos, "SexoId", "TipoSexo", pacientes.Sexo);
            ViewData["TipoSeguro"] = new SelectList(_context.Seguros, "TipoSeguroId", "Seguro1", pacientes.TipoSeguro);
            return View(pacientes);
        }

        // GET: Pacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacientes = await _context.Pacientes.SingleOrDefaultAsync(m => m.PacienteId == id);
            if (pacientes == null)
            {
                return NotFound();
            }
            ViewData["Identificacion"] = new SelectList(_context.Identificacions, "IdentificacionId", "TipoIdentificacion", pacientes.Identificacion);
            ViewData["Sexo"] = new SelectList(_context.Sexos, "SexoId", "TipoSexo", pacientes.Sexo);
            ViewData["TipoSeguro"] = new SelectList(_context.Seguros, "TipoSeguroId", "Seguro1", pacientes.TipoSeguro);
            return View(pacientes);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PacienteId,Nombre,Apellido,Sexo,Identificacion,NumeroIdentificacion,TelefonoCasa,TelefonoCelular,FechaNacimiento,Edad,TipoSeguro,FechaPrimeraVez")] Pacientes pacientes)
        {
            if (id != pacientes.PacienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacientesExists(pacientes.PacienteId))
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
            ViewData["Identificacion"] = new SelectList(_context.Identificacions, "IdentificacionId", "TipoIdentificacion", pacientes.Identificacion);
            ViewData["Sexo"] = new SelectList(_context.Sexos, "SexoId", "TipoSexo", pacientes.Sexo);
            ViewData["TipoSeguro"] = new SelectList(_context.Seguros, "TipoSeguroId", "Seguro1", pacientes.TipoSeguro);
            return View(pacientes);
        }

        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacientes = await _context.Pacientes
                .Include(p => p.IdentificacionNavigation)
                .Include(p => p.SexoNavigation)
                .Include(p => p.TipoSeguroNavigation)
                .SingleOrDefaultAsync(m => m.PacienteId == id);
            if (pacientes == null)
            {
                return NotFound();
            }

            return View(pacientes);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacientes = await _context.Pacientes.SingleOrDefaultAsync(m => m.PacienteId == id);
            _context.Pacientes.Remove(pacientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacientesExists(int id)
        {
            return _context.Pacientes.Any(e => e.PacienteId == id);
        }
    }
}
