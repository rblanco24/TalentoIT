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
    public class GeoController : Controller
    {
        private readonly DataContext _context;

        public GeoController(DataContext context)
        {
            _context = context;
        }

        // GET: Geo
        public async Task<IActionResult> Index()
        {
            return View(await _context.GeoEntity.ToListAsync());
        }

        // GET: Geo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var geoEntity = await _context.GeoEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (geoEntity == null)
            {
                return NotFound();
            }

            return View(geoEntity);
        }

        // GET: Geo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Geo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,lat,lng")] GeoEntity geoEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(geoEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(geoEntity);
        }

        // GET: Geo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var geoEntity = await _context.GeoEntity.FindAsync(id);
            if (geoEntity == null)
            {
                return NotFound();
            }
            return View(geoEntity);
        }

        // POST: Geo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,lat,lng")] GeoEntity geoEntity)
        {
            if (id != geoEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(geoEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeoEntityExists(geoEntity.Id))
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
            return View(geoEntity);
        }

        // GET: Geo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var geoEntity = await _context.GeoEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (geoEntity == null)
            {
                return NotFound();
            }

            return View(geoEntity);
        }

        // POST: Geo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var geoEntity = await _context.GeoEntity.FindAsync(id);
            _context.GeoEntity.Remove(geoEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeoEntityExists(int id)
        {
            return _context.GeoEntity.Any(e => e.Id == id);
        }
    }
}
