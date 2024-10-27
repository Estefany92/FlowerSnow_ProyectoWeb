using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerSnow_ProyectoWeb.Models
{
    public class Producto
    {
        [ Key]
        public int  ProductoId { get; set; }
        [Required]
        [StringLength(50)]

        public string Codigo { get; set; } = null;
        [Required]
        [StringLength(255)]
        public string Nombre { get; set; } = null;
        [Required]
        [StringLength(255)]
        public string Modelo { get; set; } = null;
        [Required]
        [StringLength(1000)]
        public string Descripcion { get; set; } = null;
        [Required]
        public string Precio { get; set; } = null;
        [Required]
        [StringLength(255)]
        public string Imagen { get; set; } = null;
        [Required]
        
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        //Para que se relacione con la clase categoria
        public Categoria Categoria { get; set; }
        [Required]
        
        public int Stock { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        [StringLength(100)]
        public string Marca { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
     
        public bool Activo { get; set; } //Si esta disponible o no 

        public ICollection<Detalle_Pedido> DetallesPedido{ get; set; } = null;
    }
}
