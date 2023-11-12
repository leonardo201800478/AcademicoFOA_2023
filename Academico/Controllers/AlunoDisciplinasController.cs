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
    public class AlunoDisciplinasController : Controller
    {
        private readonly AcademicoContext _context;

        public AlunoDisciplinasController(AcademicoContext context)
        {
            _context = context;
        }

        // GET: AlunoDisciplinas
        public async Task<IActionResult> Index()
        {
            var academicoContext = _context.AlunoDisciplinas.Include(a => a.Aluno).Include(a => a.Disciplina);
            return View(await academicoContext.ToListAsync());
        }

        // GET: AlunoDisciplinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AlunoDisciplinas == null)
            {
                return NotFound();
            }

            var alunoDisciplina = await _context.AlunoDisciplinas
                .Include(a => a.Aluno)
                .Include(a => a.Disciplina)
                .FirstOrDefaultAsync(m => m.AlunoId == id);
            if (alunoDisciplina == null)
            {
                return NotFound();
            }

            return View(alunoDisciplina);
        }

        // GET: AlunoDisciplinas/Create
        public IActionResult Create()
        {
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "AlunoId", "AlunoId");
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplinas, "DisciplinaId", "DisciplinaId");
            return View();
        }

        // POST: AlunoDisciplinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlunoDisciplinaId,AlunoId,DisciplinaId")] AlunoDisciplina alunoDisciplina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alunoDisciplina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "AlunoId", "AlunoId", alunoDisciplina.AlunoId);
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplinas, "DisciplinaId", "DisciplinaId", alunoDisciplina.DisciplinaId);
            return View(alunoDisciplina);
        }

        // GET: AlunoDisciplinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AlunoDisciplinas == null)
            {
                return NotFound();
            }

            var alunoDisciplina = await _context.AlunoDisciplinas.FindAsync(id);
            if (alunoDisciplina == null)
            {
                return NotFound();
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "AlunoId", "AlunoId", alunoDisciplina.AlunoId);
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplinas, "DisciplinaId", "DisciplinaId", alunoDisciplina.DisciplinaId);
            return View(alunoDisciplina);
        }

        // POST: AlunoDisciplinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlunoDisciplinaId,AlunoId,DisciplinaId")] AlunoDisciplina alunoDisciplina)
        {
            if (id != alunoDisciplina.AlunoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alunoDisciplina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoDisciplinaExists(alunoDisciplina.AlunoId))
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
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "AlunoId", "AlunoId", alunoDisciplina.AlunoId);
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplinas, "DisciplinaId", "DisciplinaId", alunoDisciplina.DisciplinaId);
            return View(alunoDisciplina);
        }

        // GET: AlunoDisciplinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AlunoDisciplinas == null)
            {
                return NotFound();
            }

            var alunoDisciplina = await _context.AlunoDisciplinas
                .Include(a => a.Aluno)
                .Include(a => a.Disciplina)
                .FirstOrDefaultAsync(m => m.AlunoId == id);
            if (alunoDisciplina == null)
            {
                return NotFound();
            }

            return View(alunoDisciplina);
        }

        // POST: AlunoDisciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AlunoDisciplinas == null)
            {
                return Problem("Entity set 'AcademicoContext.AlunoDisciplinas'  is null.");
            }
            var alunoDisciplina = await _context.AlunoDisciplinas.FindAsync(id);
            if (alunoDisciplina != null)
            {
                _context.AlunoDisciplinas.Remove(alunoDisciplina);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoDisciplinaExists(int id)
        {
          return (_context.AlunoDisciplinas?.Any(e => e.AlunoId == id)).GetValueOrDefault();
        }
    }
}
