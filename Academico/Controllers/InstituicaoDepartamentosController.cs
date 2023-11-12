using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Academico.Data;
using Academico.Models;

namespace Academico.Controllers
{
    public class InstituicaoDepartamentosController : Controller
    {
        private readonly AcademicoContext _context;

        public InstituicaoDepartamentosController(AcademicoContext context)
        {
            _context = context;
        }

        // GET: InstituicaoDepartamentos
        public async Task<IActionResult> Index()
        {
              return _context.InstituicaoDepartamentos != null ? 
                          View(await _context.InstituicaoDepartamentos.ToListAsync()) :
                          Problem("Entity set 'AcademicoContext.InstituicaoDepartamentos'  is null.");
        }

        // GET: InstituicaoDepartamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InstituicaoDepartamentos == null)
            {
                return NotFound();
            }

            var instituicaoDepartamento = await _context.InstituicaoDepartamentos
                .FirstOrDefaultAsync(m => m.InstituicaoId == id);
            if (instituicaoDepartamento == null)
            {
                return NotFound();
            }

            return View(instituicaoDepartamento);
        }

        // GET: InstituicaoDepartamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InstituicaoDepartamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstituicaoDepartamentoId,InstituicaoId,DepartamentoId")] InstituicaoDepartamento instituicaoDepartamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instituicaoDepartamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instituicaoDepartamento);
        }

        // GET: InstituicaoDepartamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InstituicaoDepartamentos == null)
            {
                return NotFound();
            }

            var instituicaoDepartamento = await _context.InstituicaoDepartamentos.FindAsync(id);
            if (instituicaoDepartamento == null)
            {
                return NotFound();
            }
            return View(instituicaoDepartamento);
        }

        // POST: InstituicaoDepartamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("InstituicaoDepartamentoId,InstituicaoId,DepartamentoId")] InstituicaoDepartamento instituicaoDepartamento)
        {
            if (id != instituicaoDepartamento.InstituicaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instituicaoDepartamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstituicaoDepartamentoExists(instituicaoDepartamento.InstituicaoId))
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
            return View(instituicaoDepartamento);
        }

        // GET: InstituicaoDepartamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InstituicaoDepartamentos == null)
            {
                return NotFound();
            }

            var instituicaoDepartamento = await _context.InstituicaoDepartamentos
                .FirstOrDefaultAsync(m => m.InstituicaoId == id);
            if (instituicaoDepartamento == null)
            {
                return NotFound();
            }

            return View(instituicaoDepartamento);
        }

        // POST: InstituicaoDepartamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.InstituicaoDepartamentos == null)
            {
                return Problem("Entity set 'AcademicoContext.InstituicaoDepartamentos'  is null.");
            }
            var instituicaoDepartamento = await _context.InstituicaoDepartamentos.FindAsync(id);
            if (instituicaoDepartamento != null)
            {
                _context.InstituicaoDepartamentos.Remove(instituicaoDepartamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstituicaoDepartamentoExists(int? id)
        {
          return (_context.InstituicaoDepartamentos?.Any(e => e.InstituicaoId == id)).GetValueOrDefault();
        }
    }
}
