using System.ComponentModel.DataAnnotations;

namespace FlowerSnow_ProyectoWeb.Models
{
    // solo se crea para distinguir entre un rol y otro 
    public class Rol
    {
        [Key]
        public int RolId { get; set; }
        //pblligatoria
        [Required(ErrorMessage = "El campo es obligatorio")]
        [StringLength(50)] //maximo de caracteres
        public string Nombre { get; set; } = null!;
    }
}
