using Microsoft.EntityFrameworkCore;
using PruebaReseñaLibros.Models;
using System.Reflection;

namespace PruebaReseñaLibros.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Libros> Libro { get; set; }
        public DbSet<Reseñas> Reseña { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
