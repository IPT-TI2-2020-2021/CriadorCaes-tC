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
   public class FotografiasController : Controller {

      /// <summary>
      /// atributo que referencia a Base de Dados do projeto
      /// </summary>
      private readonly CriadorCaesBD _db;

      public FotografiasController(
         CriadorCaesBD context) {
         _db = context;
      }

      // GET: Fotografias
      public async Task<IActionResult> Index() {

         /* o comando seguinte é equivalente
          * SELECT *
          * FROM Fotografia f, Caes c
          * WHERE f.caoFK = c.id
          */
         var listaFotosCaes = _db.Fotografias.Include(f => f.Cao);  // LINQ

         // invocar a View, entregando-lhe os dados devolvidos pela BD
         // sendo transformados numa LISTA assíncrona
         return View(await listaFotosCaes.ToListAsync());
      }

      // GET: Fotografias/Details/5
      public async Task<IActionResult> Details(int? id) {
         if (id == null) {
            return NotFound();
         }

         var fotografias = await _db.Fotografias
             .Include(f => f.Cao)
             .FirstOrDefaultAsync(m => m.Id == id);
         if (fotografias == null) {
            return NotFound();
         }

         return View(fotografias);
      }

      // GET: Fotografias/Create
      public IActionResult Create() {

         // prepara os dados a serem enviados para a View
         // para a Dropdown
         ViewData["CaoFK"] = new SelectList(_db.Caes.OrderBy(c => c.Nome), "Id", "Nome");

         return View();
      }

      // POST: Fotografias/Create
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create([Bind("Id,Fotografia,DataFoto,Local,CaoFK")] Fotografias foto) {

         if (foto.CaoFK > 0) {
            try {
               if (ModelState.IsValid) {
                  // se o Estado do Modelo for válido 
                  // ie., se os dados do objeto 'foto' estiverem de acordo com as regras definidas
                  // no modelo (classe Fotografias)

                  // adicionar os dados da 'foto' à base de dados
                  _db.Add(foto);

                  // consolidar as alterações na base de dados
                  // COMMIT
                  await _db.SaveChangesAsync();

                  // redireciona a execução do código para a método Index    
                  return RedirectToAction(nameof(Index));
               }
            }
            catch (Exception) {
               ModelState.AddModelError("", "Ocorreu um erro com a introdução dos dados da Fotografia.");
            }
         }
         else {
            ModelState.AddModelError("", "Não se esqueça de escolher um cão...");
         }

         ViewData["CaoFK"] = new SelectList(_db.Caes.OrderBy(c => c.Nome), "Id", "Nome", foto.CaoFK);

         return View(foto);
      }







      // GET: Fotografias/Edit/5
      public async Task<IActionResult> Edit(int? id) {
         if (id == null) {
            return NotFound();
         }

         var fotografias = await _db.Fotografias.FindAsync(id);
         if (fotografias == null) {
            return NotFound();
         }
         ViewData["CaoFK"] = new SelectList(_db.Caes.OrderBy(c => c.Nome), "Id", "Nome", fotografias.CaoFK);
         return View(fotografias);
      }

      // POST: Fotografias/Edit/5
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(int id, [Bind("Id,Fotografia,DataFoto,Local,CaoFK")] Fotografias fotografias) {
         if (id != fotografias.Id) {
            return NotFound();
         }

         if (ModelState.IsValid) {
            try {
               _db.Update(fotografias);
               await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
               if (!FotografiasExists(fotografias.Id)) {
                  return NotFound();
               }
               else {
                  throw;
               }
            }
            return RedirectToAction(nameof(Index));
         }
         ViewData["CaoFK"] = new SelectList(_db.Caes, "Id", "Id", fotografias.CaoFK);
         return View(fotografias);
      }

      // GET: Fotografias/Delete/5
      public async Task<IActionResult> Delete(int? id) {
         if (id == null) {
            return NotFound();
         }

         var fotografias = await _db.Fotografias
             .Include(f => f.Cao)
             .FirstOrDefaultAsync(m => m.Id == id);
         if (fotografias == null) {
            return NotFound();
         }

         return View(fotografias);
      }

      // POST: Fotografias/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteConfirmed(int id) {
         var fotografias = await _db.Fotografias.FindAsync(id);
         _db.Fotografias.Remove(fotografias);
         await _db.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
      }

      private bool FotografiasExists(int id) {
         return _db.Fotografias.Any(e => e.Id == id);
      }
   }
}
