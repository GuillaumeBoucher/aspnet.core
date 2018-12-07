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
    public class PersonContactsController : Controller
    {
        private readonly CmdbContext _context;

        public PersonContactsController(CmdbContext context)
        {
            _context = context;
        }

        // GET: PersonContacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonContacts.ToListAsync());
        }

        // GET: PersonContacts/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personContact = await _context.PersonContacts
                .FirstOrDefaultAsync(m => m.ContactID == id);
            if (personContact == null)
            {
                return NotFound();
            }

            return View(personContact);
        }

        // GET: PersonContacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactID,Title,FirstName,MiddleName,LastName,HomePhone,MobilePhone")] PersonContact personContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personContact);
        }

        // GET: PersonContacts/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personContact = await _context.PersonContacts.FindAsync(id);
            if (personContact == null)
            {
                return NotFound();
            }
            return View(personContact);
        }

        // POST: PersonContacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ContactID,Title,FirstName,MiddleName,LastName,HomePhone,MobilePhone")] PersonContact personContact)
        {
            if (id != personContact.ContactID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonContactExists(personContact.ContactID))
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
            return View(personContact);
        }

        // GET: PersonContacts/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personContact = await _context.PersonContacts
                .FirstOrDefaultAsync(m => m.ContactID == id);
            if (personContact == null)
            {
                return NotFound();
            }

            return View(personContact);
        }

        // POST: PersonContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var personContact = await _context.PersonContacts.FindAsync(id);
            _context.PersonContacts.Remove(personContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonContactExists(long id)
        {
            return _context.PersonContacts.Any(e => e.ContactID == id);
        }
    }
}
