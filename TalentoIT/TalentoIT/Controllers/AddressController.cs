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
    public class AddressController : Controller
    {
        private readonly DataContext _context;

        public AddressController(DataContext context)
        {
            _context = context;
        }

        // GET: Address
        public async Task<IActionResult> Index()
        {
            return View(await _context.AddressEntity.ToListAsync());
        }

        // GET: Address/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressEntity = await _context.AddressEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addressEntity == null)
            {
                return NotFound();
            }

            return View(addressEntity);
        }

        // GET: Address/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Address/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,street,suite,city,zipcode")] AddressEntity addressEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addressEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addressEntity);
        }

        // GET: Address/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressEntity = await _context.AddressEntity.FindAsync(id);
            if (addressEntity == null)
            {
                return NotFound();
            }
            return View(addressEntity);
        }

        // POST: Address/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,street,suite,city,zipcode")] AddressEntity addressEntity)
        {
            if (id != addressEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addressEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressEntityExists(addressEntity.Id))
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
            return View(addressEntity);
        }

        // GET: Address/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressEntity = await _context.AddressEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addressEntity == null)
            {
                return NotFound();
            }

            return View(addressEntity);
        }

        // POST: Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addressEntity = await _context.AddressEntity.FindAsync(id);
            _context.AddressEntity.Remove(addressEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressEntityExists(int id)
        {
            return _context.AddressEntity.Any(e => e.Id == id);
        }
    }
}
