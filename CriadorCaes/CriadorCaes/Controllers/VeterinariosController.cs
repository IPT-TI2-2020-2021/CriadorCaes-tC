using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CriadorCaes.Data;
using CriadorCaes.Models;

namespace CriadorCaes.Controllers {
   public class VeterinariosController : Controller {
      private readonly CriadorCaesBD _context;

      public VeterinariosController(CriadorCaesBD context) {
         _context = context;
      }

      // GET: Veterinarios
      public async Task<IActionResult> Index() {
         return View(await _context.Veterinarios.ToListAsync());
      }

      // GET: Veterinarios/Details/5
      public async Task<IActionResult> Details(int? id) {
         if (id == null) {
            return NotFound();
         }

         var veterinarios = await _context.Veterinarios
             .FirstOrDefaultAsync(m => m.Id == id);
         if (veterinarios == null) {
            return NotFound();
         }

         return View(veterinarios);
      }

      // GET: Veterinarios/Create
      public IActionResult Create() {
         return View();
      }

      // POST: Veterinarios/Create
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create([Bind("Nome,HonorarioAux")] Veterinarios veterinario) {

         // transferir os dados do atibuto HonorarioAux para o atributo Honorario
         string auxHonorario = veterinario.HonorarioAux.Replace('.', ',');
         veterinario.Honorario = Convert.ToDecimal(auxHonorario);
         //  veterinario.Honorario = Convert.ToDecimal(veterinario.HonorarioAux.Replace('.', ','));

         if (ModelState.IsValid) {
            _context.Add(veterinario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
         }
         return View(veterinario);
      }

      // GET: Veterinarios/Edit/5
      public async Task<IActionResult> Edit(int? id) {
         if (id == null) {
            return NotFound();
         }

         var veterinarios = await _context.Veterinarios.FindAsync(id);
         if (veterinarios == null) {
            return NotFound();
         }
         return View(veterinarios);
      }

      // POST: Veterinarios/Edit/5
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Honorario")] Veterinarios veterinarios) {
         if (id != veterinarios.Id) {
            return NotFound();
         }

         if (ModelState.IsValid) {
            try {
               _context.Update(veterinarios);
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
               if (!VeterinariosExists(veterinarios.Id)) {
                  return NotFound();
               }
               else {
                  throw;
               }
            }
            return RedirectToAction(nameof(Index));
         }
         return View(veterinarios);
      }

      // GET: Veterinarios/Delete/5
      public async Task<IActionResult> Delete(int? id) {
         if (id == null) {
            return NotFound();
         }

         var veterinarios = await _context.Veterinarios
             .FirstOrDefaultAsync(m => m.Id == id);
         if (veterinarios == null) {
            return NotFound();
         }

         return View(veterinarios);
      }

      // POST: Veterinarios/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteConfirmed(int id) {
         var veterinarios = await _context.Veterinarios.FindAsync(id);
         _context.Veterinarios.Remove(veterinarios);
         await _context.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
      }

      private bool VeterinariosExists(int id) {
         return _context.Veterinarios.Any(e => e.Id == id);
      }
   }
}
