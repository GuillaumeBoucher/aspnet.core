using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AddressTypesController : Controller
    {
        private readonly CmdbContext _context;

        public AddressTypesController(CmdbContext context)
        {
            _context = context;
        }

        // GET: AddressTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AddressType.ToListAsync());
        }

        // GET: AddressTypes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressType = await _context.AddressType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addressType == null)
            {
                return NotFound();
            }

            return View(addressType);
        }

        // GET: AddressTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddressTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AddressTitle,Address,City,Region,PostalCode,Country,Phone,Fax")] AddressType addressType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addressType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addressType);
        }

        // GET: AddressTypes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressType = await _context.AddressType.FindAsync(id);
            if (addressType == null)
            {
                return NotFound();
            }
            return View(addressType);
        }

        // POST: AddressTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,AddressTitle,Address,City,Region,PostalCode,Country,Phone,Fax")] AddressType addressType)
        {
            if (id != addressType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addressType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressTypeExists(addressType.Id))
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
            return View(addressType);
        }

        // GET: AddressTypes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressType = await _context.AddressType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addressType == null)
            {
                return NotFound();
            }

            return View(addressType);
        }

        // POST: AddressTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var addressType = await _context.AddressType.FindAsync(id);
            _context.AddressType.Remove(addressType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressTypeExists(long id)
        {
            return _context.AddressType.Any(e => e.Id == id);
        }
    }
}
