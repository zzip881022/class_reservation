using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using reservation_new.Data;
using reservation_new.Models;

namespace reservation_new.Controllers
{
    public class GuestResponsesController : Controller
    {
        private readonly GuestResponseContext _context;

        public GuestResponsesController(GuestResponseContext context)
        {
            _context = context;
        }

        // GET: GuestResponses
        public async Task<IActionResult> Index()
        {
            return View(await _context.responses.ToListAsync());
        }

        // GET: GuestResponses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestResponse = await _context.responses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (guestResponse == null)
            {
                return NotFound();
            }

            return View(guestResponse);
        }

        // GET: GuestResponses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GuestResponses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,name,email,phone,WillAttend")] GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guestResponse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guestResponse);
        }

        // GET: GuestResponses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestResponse = await _context.responses.FindAsync(id);
            if (guestResponse == null)
            {
                return NotFound();
            }
            return View(guestResponse);
        }

        // POST: GuestResponses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,name,email,phone,WillAttend")] GuestResponse guestResponse)
        {
            if (id != guestResponse.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guestResponse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestResponseExists(guestResponse.ID))
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
            return View(guestResponse);
        }

        // GET: GuestResponses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestResponse = await _context.responses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (guestResponse == null)
            {
                return NotFound();
            }

            return View(guestResponse);
        }

        // POST: GuestResponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guestResponse = await _context.responses.FindAsync(id);
            _context.responses.Remove(guestResponse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuestResponseExists(int id)
        {
            return _context.responses.Any(e => e.ID == id);
        }
    }
}
