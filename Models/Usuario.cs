using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerSnow_ProyectoWeb.Models
{
    public class Usuario
    {
        //se realiza est constructor ya que pedido no acepta valores nulos al inicio pero si luego de ser procesado
        public Usuario()
        {
            Pedidos = new List<Pedido>();
            Direcciones= new List<Direccion>();

        }
      

        [Key]
        public int UsuarioId { get; set; }
        
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        [StringLength(50)]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        [StringLength(15)]
        public string telefono { get; set; } = null!;

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        [StringLength(50)]
        public string NombreUsuario { get; set; } = null!;

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        [StringLength(255)]
        public string Contrasenia { get; set; } = null!;

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        [StringLength(255)]
        public string Correo { get; set; } = null!;

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        [StringLength(100)]
        public string Direccion { get; set; } = null!;

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        [StringLength(20)]
        public string Ciudad { get; set; } = null!;

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        [StringLength(20)]
        public string CodigoPostal { get; set; } = null!;

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public int RolId { get; set; }
        //relacion de clave foreana con la tabla Rol 
        [ForeignKey("RolId")]
        public Rol Rol { get; set; } = null!;

        public ICollection<Pedido> Pedidos { get; set; }

        //hace referencia a ala tabla usruario asociando
        public ICollection<Direccion> Direcciones { get; set; } = null!;


    }
}
