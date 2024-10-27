using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerSnow_ProyectoWeb.Models
{
    public class Direccion
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        [StringLength(50)]

        public string Address { get; set; } = null!;
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        [StringLength(20)]
        public string Ciudad { get; set; } = null!;

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        [StringLength(20)]
        public string CodigoPostal { get; set; } = null!;

        public int UsuarioId { get; set; }


        [ForeignKey("UsuarioId")]


        public Usuario Usuario { get; set; } = null!;



    }
}
