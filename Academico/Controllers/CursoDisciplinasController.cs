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
    public class CursoDisciplinasController : Controller
    {
        private readonly AcademicoContext _context;

        public CursoDisciplinasController(AcademicoContext context)
        {
            _context = context;
        }

        // GET: CursoDisciplinas
        public async Task<IActionResult> Index()
        {
            var academicoContext = _context.CursoDisciplinas.Include(c => c.Curso).Include(c => c.Disciplina);
            return View(await academicoContext.ToListAsync());
        }

        // GET: CursoDisciplinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CursoDisciplinas == null)
            {
                return NotFound();
            }

            var cursoDisciplina = await _context.CursoDisciplinas
                .Include(c => c.Curso)
                .Include(c => c.Disciplina)
                .FirstOrDefaultAsync(m => m.CursoId == id);
            if (cursoDisciplina == null)
            {
                return NotFound();
            }

            return View(cursoDisciplina);
        }

        // GET: CursoDisciplinas/Create
        public IActionResult Create()
        {
            ViewData["CursoId"] = new SelectList(_context.Cursos, "CursoId", "CursoId");
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplinas, "DisciplinaId", "DisciplinaId");
            return View();
        }

        // POST: CursoDisciplinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CursoDisciplinaId,CursoId,DisciplinaId")] CursoDisciplina cursoDisciplina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursoDisciplina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "CursoId", "CursoId", cursoDisciplina.CursoId);
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplinas, "DisciplinaId", "DisciplinaId", cursoDisciplina.DisciplinaId);
            return View(cursoDisciplina);
        }

        // GET: CursoDisciplinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CursoDisciplinas == null)
            {
                return NotFound();
            }

            var cursoDisciplina = await _context.CursoDisciplinas.FindAsync(id);
            if (cursoDisciplina == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "CursoId", "CursoId", cursoDisciplina.CursoId);
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplinas, "DisciplinaId", "DisciplinaId", cursoDisciplina.DisciplinaId);
            return View(cursoDisciplina);
        }

        // POST: CursoDisciplinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CursoDisciplinaId,CursoId,DisciplinaId")] CursoDisciplina cursoDisciplina)
        {
            if (id != cursoDisciplina.CursoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursoDisciplina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoDisciplinaExists(cursoDisciplina.CursoId))
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
            ViewData["CursoId"] = new SelectList(_context.Cursos, "CursoId", "CursoId", cursoDisciplina.CursoId);
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplinas, "DisciplinaId", "DisciplinaId", cursoDisciplina.DisciplinaId);
            return View(cursoDisciplina);
        }

        // GET: CursoDisciplinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CursoDisciplinas == null)
            {
                return NotFound();
            }

            var cursoDisciplina = await _context.CursoDisciplinas
                .Include(c => c.Curso)
                .Include(c => c.Disciplina)
                .FirstOrDefaultAsync(m => m.CursoId == id);
            if (cursoDisciplina == null)
            {
                return NotFound();
            }

            return View(cursoDisciplina);
        }

        // POST: CursoDisciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CursoDisciplinas == null)
            {
                return Problem("Entity set 'AcademicoContext.CursoDisciplinas'  is null.");
            }
            var cursoDisciplina = await _context.CursoDisciplinas.FindAsync(id);
            if (cursoDisciplina != null)
            {
                _context.CursoDisciplinas.Remove(cursoDisciplina);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoDisciplinaExists(int id)
        {
          return (_context.CursoDisciplinas?.Any(e => e.CursoId == id)).GetValueOrDefault();
        }
    }
}
