﻿using System;
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
    public class DisciplinasController : Controller
    {
        private readonly AcademicoContext _context;

        public DisciplinasController(AcademicoContext context)
        {
            _context = context;
        }

        // GET: Disciplinas
        public async Task<IActionResult> Index()
        {
              return _context.Disciplinas != null ? 
                          View(await _context.Disciplinas.ToListAsync()) :
                          Problem("Entity set 'AcademicoContext.Disciplinas'  is null.");
        }

        // GET: Disciplinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Disciplinas == null)
            {
                return NotFound();
            }

            var disciplina = await _context.Disciplinas
                .FirstOrDefaultAsync(m => m.DisciplinaId == id);
            if (disciplina == null)
            {
                return NotFound();
            }

            return View(disciplina);
        }

        // GET: Disciplinas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Disciplinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DisciplinaId,Nome")] Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disciplina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disciplina);
        }

        // GET: Disciplinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Disciplinas == null)
            {
                return NotFound();
            }

            var disciplina = await _context.Disciplinas.FindAsync(id);
            if (disciplina == null)
            {
                return NotFound();
            }
            return View(disciplina);
        }

        // POST: Disciplinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DisciplinaId,Nome")] Disciplina disciplina)
        {
            if (id != disciplina.DisciplinaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disciplina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisciplinaExists(disciplina.DisciplinaId))
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
            return View(disciplina);
        }

        // GET: Disciplinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Disciplinas == null)
            {
                return NotFound();
            }

            var disciplina = await _context.Disciplinas
                .FirstOrDefaultAsync(m => m.DisciplinaId == id);
            if (disciplina == null)
            {
                return NotFound();
            }

            return View(disciplina);
        }

        // POST: Disciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Disciplinas == null)
            {
                return Problem("Entity set 'AcademicoContext.Disciplinas'  is null.");
            }
            var disciplina = await _context.Disciplinas.FindAsync(id);
            if (disciplina != null)
            {
                _context.Disciplinas.Remove(disciplina);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisciplinaExists(int id)
        {
          return (_context.Disciplinas?.Any(e => e.DisciplinaId == id)).GetValueOrDefault();
        }
    }
}
