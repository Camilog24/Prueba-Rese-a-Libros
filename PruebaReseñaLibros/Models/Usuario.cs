using System.ComponentModel.DataAnnotations;

namespace PruebaReseñaLibros.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Nombre es requerido")]
        [MaxLength(100, ErrorMessage = "Nombre debe ser maximo de 100 Caracteres ")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Apellidos es requerido")]
        [MaxLength(100, ErrorMessage = "Apellidos debe ser maximo de 100 Caracteres ")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Correo es requerido")]
        [MaxLength(100, ErrorMessage = "Correo debe ser maximo de 100 Caracteres ")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Contraseña es requerido")]
        [MaxLength(100)]
        public string Contraseña { get; set; }
    }
}
