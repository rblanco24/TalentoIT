using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TalentoIT.Data;
using TalentoIT.Data.Entities;

namespace TalentoIT.Controllers
{
    public class TecnologiaController : Controller
    {
        private readonly DataContext _context;

        public TecnologiaController(DataContext context)
        {
            _context = context;
        }

        // GET: Tecnologia
        public async Task<IActionResult> Index()
        {
            return View(await _context.TecnologiaEntity.ToListAsync());
        }

        // GET: Tecnologia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnologiaEntity = await _context.TecnologiaEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tecnologiaEntity == null)
            {
                return NotFound();
            }

            return View(tecnologiaEntity);
        }

        // GET: Tecnologia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tecnologia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoTecnologia,Nombre")] TecnologiaEntity tecnologiaEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tecnologiaEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tecnologiaEntity);
        }

        // GET: Tecnologia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnologiaEntity = await _context.TecnologiaEntity.FindAsync(id);
            if (tecnologiaEntity == null)
            {
                return NotFound();
            }
            return View(tecnologiaEntity);
        }

        // POST: Tecnologia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoTecnologia,Nombre")] TecnologiaEntity tecnologiaEntity)
        {
            if (id != tecnologiaEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tecnologiaEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TecnologiaEntityExists(tecnologiaEntity.Id))
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
            return View(tecnologiaEntity);
        }

        // GET: Tecnologia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnologiaEntity = await _context.TecnologiaEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tecnologiaEntity == null)
            {
                return NotFound();
            }

            return View(tecnologiaEntity);
        }

        // POST: Tecnologia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tecnologiaEntity = await _context.TecnologiaEntity.FindAsync(id);
            _context.TecnologiaEntity.Remove(tecnologiaEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TecnologiaEntityExists(int id)
        {
            return _context.TecnologiaEntity.Any(e => e.Id == id);
        }
    }
}
