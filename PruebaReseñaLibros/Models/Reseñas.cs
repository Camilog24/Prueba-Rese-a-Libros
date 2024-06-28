using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaReseñaLibros.Models
{
  
    public class Reseñas
    {
        [Key]
        public int idReseña { get; set; }
        public int idLibro { get; set; }

        [Required(ErrorMessage = "La reseña es requerida")]
        [MaxLength(1000, ErrorMessage = "La reseña debe tener  máximo  1000 caracteres")]
        public string Contenido { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }


    }
}
