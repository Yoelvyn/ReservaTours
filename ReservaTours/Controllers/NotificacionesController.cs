using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReservaTours.Data;
using ReservaTours.Models;

namespace ReservaTours.Controllers
{
    public class NotificacionesController : Controller
    {
        private readonly ReservaToursDbContext _context;

        public NotificacionesController(ReservaToursDbContext context)
        {
            _context = context;
        }

        // GET: Notificaciones
        public async Task<IActionResult> Index()
        {
            var reservaToursDbContext = _context.Notificaciones.Include(n => n.Usuario);
            return View(await reservaToursDbContext.ToListAsync());
        }

        // GET: Notificaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notificacione = await _context.Notificaciones
                .Include(n => n.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notificacione == null)
            {
                return NotFound();
            }

            return View(notificacione);
        }

        // GET: Notificaciones/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: Notificaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,Mensaje,FechaEnvio")] Notificaciones notificacione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notificacione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", notificacione.UsuarioId);
            return View(notificacione);
        }

        // GET: Notificaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notificacione = await _context.Notificaciones.FindAsync(id);
            if (notificacione == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", notificacione.UsuarioId);
            return View(notificacione);
        }

        // POST: Notificaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,Mensaje,FechaEnvio")] Notificaciones notificacione)
        {
            if (id != notificacione.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notificacione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificacioneExists(notificacione.Id))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", notificacione.UsuarioId);
            return View(notificacione);
        }

        // GET: Notificaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notificacione = await _context.Notificaciones
                .Include(n => n.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notificacione == null)
            {
                return NotFound();
            }

            return View(notificacione);
        }

        // POST: Notificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notificacione = await _context.Notificaciones.FindAsync(id);
            if (notificacione != null)
            {
                _context.Notificaciones.Remove(notificacione);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotificacioneExists(int id)
        {
            return _context.Notificaciones.Any(e => e.Id == id);
        }
    }
}
