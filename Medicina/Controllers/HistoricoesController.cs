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
    public class HistoricoesController : Controller
    {
        private readonly EasyMedicineContext _context;

        public HistoricoesController(EasyMedicineContext context)
        {
            _context = context;
        }

        // GET: Historicoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Historicoes.ToListAsync());
        }

        // GET: Historicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historicoes = await _context.Historicoes
                .SingleOrDefaultAsync(m => m.HistoricoId == id);
            if (historicoes == null)
            {
                return NotFound();
            }

            return View(historicoes);
        }

        // GET: Historicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Historicoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistoricoId,Nombre,Apellido,NumeroIdentificacion,AntecendesPersonales,MotivoConsulta,ExamenFisico,TratamientosOEstudios,ResultadoLaboratorio,Indicaciones,FechaHoy,FechaVolver,FechaPrimeraVez")] Historicoes historicoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historicoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(historicoes);
        }

        // GET: Historicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historicoes = await _context.Historicoes.SingleOrDefaultAsync(m => m.HistoricoId == id);
            if (historicoes == null)
            {
                return NotFound();
            }
            return View(historicoes);
        }

        // POST: Historicoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HistoricoId,Nombre,Apellido,NumeroIdentificacion,AntecendesPersonales,MotivoConsulta,ExamenFisico,TratamientosOEstudios,ResultadoLaboratorio,Indicaciones,FechaHoy,FechaVolver,FechaPrimeraVez")] Historicoes historicoes)
        {
            if (id != historicoes.HistoricoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historicoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoricoesExists(historicoes.HistoricoId))
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
            return View(historicoes);
        }

        public ActionResult Consulta(string Numero_Identificacion)
        {
            var pas = _context.Historicoes .OrderByDescending(c => c.HistoricoId)
                .Where(c => c.NumeroIdentificacion == Numero_Identificacion).ToList();

            if (pas.Count() == 0)
            {
                ViewBag.error = "El número de identificación no es valido";
                return View(pas);
            }
            else
                return View(pas);   
        }

        // GET: Historicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historicoes = await _context.Historicoes
                .SingleOrDefaultAsync(m => m.HistoricoId == id);
            if (historicoes == null)
            {
                return NotFound();
            }

            return View(historicoes);
        }

        // POST: Historicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historicoes = await _context.Historicoes.SingleOrDefaultAsync(m => m.HistoricoId == id);
            _context.Historicoes.Remove(historicoes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoricoesExists(int id)
        {
            return _context.Historicoes.Any(e => e.HistoricoId == id);
        }
    }
}
