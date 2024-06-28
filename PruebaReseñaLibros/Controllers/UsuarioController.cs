using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaReseñaLibros.Data;
using PruebaReseñaLibros.Models;
using PruebaReseñaLibros.ViewModels;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace ReseñaLibros.Controllers
{
    
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public UsuarioController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registro(UsuarioVM modeloUsuarioLibros)
        {
            if (modeloUsuarioLibros.Contraseña != modeloUsuarioLibros.ConfirmarContraseña)
            {
                ViewData["Mensaje"] = "Las contraseñas no son iguales";
                return View();
            }
            bool usuarioExistente = await _appDbContext.Usuarios.AnyAsync(u => u.Correo == modeloUsuarioLibros.Correo);

            if (usuarioExistente)
            {
                ViewData["Mensaje"] = "El usuario ya existe.";
                return View(modeloUsuarioLibros);
            }
            else
            {

                Usuario NuevoUsuario = new Usuario()
                {
                    Nombres = modeloUsuarioLibros.Nombres,
                    Apellidos = modeloUsuarioLibros.Apellidos,
                    Correo = modeloUsuarioLibros.Correo,
                    Contraseña = modeloUsuarioLibros.Contraseña,
                };
                await _appDbContext.Usuarios.AddAsync(NuevoUsuario);
                await _appDbContext.SaveChangesAsync();

                if (NuevoUsuario.IdUsuario != 0)
                {
                    return RedirectToAction("Login", "Usuario");
                }
                ViewData["Mensaje"] = "No Se creo con exito";
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM modeloUsuarioLibro)
        {
            Usuario? Encontrando_Usuario = await _appDbContext.Usuarios.Where(USU => USU.Correo == modeloUsuarioLibro.Correo && USU.Contraseña == modeloUsuarioLibro.Contraseña).FirstOrDefaultAsync();
            if (Encontrando_Usuario == null)
            {
                ViewData["Mensaje"] = "No Se puede encontrar el Usuario";
                return View();
            }
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, Encontrando_Usuario.Correo)
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );

            if (modeloUsuarioLibro.Correo == "admin@gmail.com")
            {
                return RedirectToAction("ListarLibros", "LibrosAdmin"); 
            }
            else
            {
                return RedirectToAction("Libreria", "Usuario"); 
            }
            
        }
        public async Task<IActionResult> Libreria()
        {
            var Traerlibros = await _appDbContext.Libro.ToListAsync();
            return View(Traerlibros);
        }
        public async Task<IActionResult> DetallesLibreria(int idLib)
        {
            if (idLib == 0)
            {
                return BadRequest("Id del libro no proporcionado");
            }
            var Detalleslibros = await _appDbContext.Libro.Include(l=>l.Reseñas).FirstOrDefaultAsync(l => l.IdTitulo == idLib);

            return View(Detalleslibros);
        }
        [HttpPost]
        public async Task<IActionResult> AgregarReseña(int IdTitulo, string Contenido)
        {

            var usuario = User.Identity.Name;
            if (string.IsNullOrEmpty(usuario))
            {
                return Unauthorized();
            }

            var libro = await _appDbContext.Libro.FirstOrDefaultAsync(l => l.IdTitulo == IdTitulo);
            if (libro == null)
            {
                return NotFound();
            }

            var Reseñas = new Reseñas
            {
                idLibro = IdTitulo,
                Contenido = Contenido,
                Usuario = usuario,
                FechaCreacion = DateTime.Now
            };

            _appDbContext.Reseña.Add(Reseñas);
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("DetallesLibreria", new { idLib = IdTitulo });

        }
        [HttpGet]
        public async Task<IActionResult> FiltrarLibros(string nombreLibro, string autor, string categoria)
        {
            IQueryable<Libros> query = _appDbContext.Libro;

            if (!string.IsNullOrEmpty(nombreLibro))
            {
                query = query.Where(l => l.TituloLibro.Contains(nombreLibro));
            }

            if (!string.IsNullOrEmpty(autor))
            {
                query = query.Where(l => l.AutorLibro.Contains(autor));
            }

            if (!string.IsNullOrEmpty(categoria))
            {
                query = query.Where(l => l.Categoria.Contains(categoria));
            }

            var librosFiltrados = await query.ToListAsync();
            return View("Libreria", librosFiltrados);
        }

    }
}

