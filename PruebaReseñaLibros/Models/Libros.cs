using System.ComponentModel.DataAnnotations;

namespace PruebaReseñaLibros.Models
{
    public class Libros
    {
        [Key]
        public int IdTitulo { get; set; }
        [Required(ErrorMessage = "Nombre del libro es requerido")]
        [MaxLength(150, ErrorMessage = "Nombre debe ser maximo de 150 Caracteres ")]
        public string TituloLibro { get; set; }
        [Required(ErrorMessage = "Autor del libro es requerido")]
        [MaxLength(150, ErrorMessage = "Nombre debe ser maximo de 150 Caracteres ")]
        public string AutorLibro { get; set; }
        [Required(ErrorMessage = "Categoria del libro es requerido")]
        [MaxLength(150, ErrorMessage = "categoria debe ser maximo de 150 Caracteres ")]
        public string Categoria { get; set; }
        [Required(ErrorMessage = "Idioma del libro es requerido")]
        [MaxLength(60, ErrorMessage = "Idioma debe ser maximo de 60 Caracteres ")]
        public string Idioma { get; set; }
        [Required(ErrorMessage = "resumen del libro es requerido")]
        [MaxLength(500, ErrorMessage = "resumen debe ser maximo de 500 Caracteres ")]
        public string Resumen { get; set; }
        [Required(ErrorMessage = "Precio del libro es requerido")]
        public double Precio { get; set; }
        [Required(ErrorMessage = "Imagen  del libro es requerido")]
       
        public byte[] ImagenLibro { get; set; }

        public ICollection<Reseñas> Reseñas { get; set; }
    }
}
