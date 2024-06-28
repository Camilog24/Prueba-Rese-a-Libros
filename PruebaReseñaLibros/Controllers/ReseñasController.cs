using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaReseñaLibros.Data;
using PruebaReseñaLibros.Models;

namespace PruebaReseñaLibros.Controllers
{
    public class ReseñasController : Controller
    {
        private readonly AppDbContext _appDbContext;
        

        public ReseñasController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> MostrarReseñas(int idTitulo)
        {
            var reseñas = await _appDbContext.Reseña
                .Where(r => r.idLibro == idTitulo)
                .ToListAsync();

            return PartialView("_ReseñasList", reseñas);
        }
        [HttpGet]
        public async Task<IActionResult> EditarReseña(int id)
        {
            var reseña = await _appDbContext.Reseña.FindAsync(id);
            if (reseña == null)
            {
                return NotFound();
            }

            if (reseña.Usuario != User.Identity.Name)
            {
                return Forbid();
            }

            return View(reseña);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarReseña(int id, Reseñas reseña)
        {
            if (id != reseña.idReseña)
            {
                return NotFound();
            }

            var reseñaExistente = await _appDbContext.Reseña.FindAsync(id);
            if (reseñaExistente == null || reseñaExistente.Usuario != User.Identity.Name)
            {
                return RedirectToAction("AccessDenied", "Reseñas");
            }  
                try
                {
                    // Update only the properties that are editable
                    reseñaExistente.Contenido = reseña.Contenido;
                    _appDbContext.Update(reseñaExistente);

                    await _appDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(MostrarReseñas), new { idTitulo = reseña.idLibro });
                    
        }
        [HttpGet]
        public async Task<IActionResult> EliminarReseña(int id)
        {
            var reseña = await _appDbContext.Reseña
                .FirstOrDefaultAsync(m => m.idReseña == id);
            if (reseña == null)
            {
                return NotFound();
            }

            if (reseña.Usuario != User.Identity.Name)
            {
                return Forbid();
            }

            return View(reseña);
        }

        [HttpPost, ActionName("EliminarReseña")]
      
        public async Task<IActionResult> ConfirmarEliminarReseña(int id)
        {
            var reseña = await _appDbContext.Reseña.FindAsync(id);
            if (reseña == null)
            {
                return NotFound();
            }

            if (reseña.Usuario != User.Identity.Name)
            {
                return Forbid();
            }

            _appDbContext.Reseña.Remove(reseña);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(MostrarReseñas), new { idTitulo = reseña.idLibro });
        }
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View(); 
        }

    }
}
