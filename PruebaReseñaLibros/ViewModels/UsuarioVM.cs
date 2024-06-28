using System.ComponentModel.DataAnnotations;

namespace PruebaReseñaLibros.ViewModels
{
    public class UsuarioVM
    {
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

        [MaxLength(100)]
        public string ConfirmarContraseña { get; set; }
    }
}
