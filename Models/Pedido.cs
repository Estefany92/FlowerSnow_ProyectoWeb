using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerSnow_ProyectoWeb.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; } = null!;
        [Required(ErrorMessage = "El campo es obligatorio")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Estado { get; set; } = null!;

        public int DireccionId { get; set; }

        [ForeignKey("UsuarioId")]
        public Direccion Direccion { get; set; } =null!;    
        public decimal Total { get; set; }
        public ICollection<Detalle_Pedido> DetallesPedido { get; set; } = null;
    }
}
