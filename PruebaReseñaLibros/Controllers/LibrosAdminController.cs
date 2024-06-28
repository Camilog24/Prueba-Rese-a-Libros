using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaReseñaLibros.Data;
using PruebaReseñaLibros.Models;
using System.Collections.Generic;


namespace PruebaReseñaLibros.Controllers
{
    public class LibrosAdminController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public LibrosAdminController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> ListarLibros()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> ObtenerLibros()
        {
            List<Libros> listarLibros = await _appDbContext.Libro.Include(i => i.Reseñas).ToListAsync();
            return Json(new { data = listarLibros });
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Crear(Libros crearLibro, IFormFile imagen)
        {
            
            
                if (imagen != null && imagen.Length > 0)
                {
                    var extensionesPermitidas = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                    var extension = Path.GetExtension(imagen.FileName).ToLowerInvariant();
                    if (!extensionesPermitidas.Contains(extension))
                    {
                        ModelState.AddModelError("ImagenLibro", "Por favor, sube una imagen válida (jpg, jpeg, png, gif).");
                        return View(crearLibro);
                    }

                    const int maxSizeInBytes = 5 * 1024 * 1024; 
                    if (imagen.Length > maxSizeInBytes)
                    {
                        ModelState.AddModelError("ImagenLibro", "El tamaño de la imagen no debe exceder los 5 MB.");
                        return View(crearLibro);
                    }

                    using (var ms = new MemoryStream())
                    {
                        await imagen.CopyToAsync(ms);
                        crearLibro.ImagenLibro = ms.ToArray();
                    }
                }
                else
                {
                    ModelState.AddModelError("ImagenLibro", "La imagen es requerida.");
                    return View(crearLibro);
                }

                try
                {
                    await _appDbContext.Libro.AddAsync(crearLibro);
                    await _appDbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(ListarLibros));
                }
                catch (DbUpdateException ex)
                {
                    
                    Console.WriteLine(ex.InnerException?.Message);
                    ModelState.AddModelError("", "Error al guardar los cambios en la base de datos. Por favor, inténtelo de nuevo.");
                    return View(crearLibro);
                }
            

            return View(crearLibro);
        }
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var libro = await _appDbContext.Libro.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Libros libro)
        {
            if (id != libro.IdTitulo)
            {
                return NotFound();
            }

          _appDbContext.Update(libro);
         await _appDbContext.SaveChangesAsync();
          return RedirectToAction(nameof(ListarLibros));         
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            var libro = await _appDbContext.Libro.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            _appDbContext.Libro.Remove(libro);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(ListarLibros));
        }


    }

    }



