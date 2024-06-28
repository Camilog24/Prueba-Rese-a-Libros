using System.ComponentModel.DataAnnotations;

namespace PruebaReseñaLibros.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Correo es requerido")]
        [MaxLength(100, ErrorMessage = "Correo debe ser maximo de 100 Caracteres ")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Contraseña es requerido")]
        [MaxLength(100)]
        public string Contraseña { get; set; }
    }
}
