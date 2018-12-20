using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoftToys.Models;

namespace SoftToys.Controllers
{
    public class Toys1Controller : Controller
    {
        private readonly SoftToysContext _context;

        public Toys1Controller(SoftToysContext context)
        {
            _context = context;
        }

        // GET: Toys1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Toys.ToListAsync());
        }

        // GET: Toys1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toys = await _context.Toys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toys == null)
            {
                return NotFound();
            }

            return View(toys);
        }

        // GET: Toys1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Toys1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,UnderAge,Price,QuantityInStock")] Toys toys)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toys);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toys);
        }

        // GET: Toys1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toys = await _context.Toys.FindAsync(id);
            if (toys == null)
            {
                return NotFound();
            }
            return View(toys);
        }

        // POST: Toys1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,UnderAge,Price,QuantityInStock")] Toys toys)
        {
            if (id != toys.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toys);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToysExists(toys.Id))
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
            return View(toys);
        }

        // GET: Toys1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toys = await _context.Toys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toys == null)
            {
                return NotFound();
            }

            return View(toys);
        }

        // POST: Toys1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toys = await _context.Toys.FindAsync(id);
            _context.Toys.Remove(toys);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToysExists(int id)
        {
            return _context.Toys.Any(e => e.Id == id);
        }
    }
}
