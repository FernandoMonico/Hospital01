using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital01.Models;

namespace Hospital01.Controllers
{
    public class BotonController : Controller
    {
        private readonly BDHospitalContext _context;

        public BotonController(BDHospitalContext context)
        {
            _context = context;
        }

        // GET: Boton
        public async Task<IActionResult> Index()
        {
            return View(await _context.Boton.ToListAsync());
        }

        // GET: Boton/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boton = await _context.Boton
                .FirstOrDefaultAsync(m => m.Iidboton == id);
            if (boton == null)
            {
                return NotFound();
            }

            return View(boton);
        }

        // GET: Boton/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Boton/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Iidboton,Nombre,Descripcion,Bhabilitado")] Boton boton)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boton);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boton);
        }

        // GET: Boton/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boton = await _context.Boton.FindAsync(id);
            if (boton == null)
            {
                return NotFound();
            }
            return View(boton);
        }

        // POST: Boton/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Iidboton,Nombre,Descripcion,Bhabilitado")] Boton boton)
        {
            if (id != boton.Iidboton)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boton);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BotonExists(boton.Iidboton))
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
            return View(boton);
        }

        // GET: Boton/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boton = await _context.Boton
                .FirstOrDefaultAsync(m => m.Iidboton == id);
            if (boton == null)
            {
                return NotFound();
            }

            return View(boton);
        }

        // POST: Boton/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boton = await _context.Boton.FindAsync(id);
            _context.Boton.Remove(boton);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BotonExists(int id)
        {
            return _context.Boton.Any(e => e.Iidboton == id);
        }
    }
}
