using FlowerSnow_ProyectoWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowerSnow_ProyectoWeb.Data
{
    //De añade DbContext para heredarlo conectarla y eliminar errores por eso se crea esta acrpeta data y esta clase
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        //Cread los Db set para cada Model debden estar pluralizados <LLAMA A LA CARPETA CON EL NOMREB>

        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Rol> Roles { get; set; } = null!;
        public DbSet<Producto> Productos { get; set; } = null!;
        public DbSet<Pedido> Pedidos { get; set; } = null!;
        public DbSet<Direccion> Direcciones { get; set; } = null!;
        public DbSet<Detalle_Pedido> Detalle_Pedidos { get; set; } = null!;
        public DbSet<Categoria> Categorias { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //relaciones uno a muchos o muchos muychos
            //usuario y pedido uno a muchos

            modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Pedidos) //muschos pedidos un usuario
            .WithOne(p => p.Usuario)
            .HasForeignKey(p => p.UsuarioId)//llave que identifica
            .OnDelete(DeleteBehavior.Cascade);   //si se elimina un usuario se eliminen los pedidos



            modelBuilder.Entity < Producto>()
            .HasMany(p => p.DetallesPedido) //muschos pedidos un usuario
            .WithOne(dp => dp.Producto)
            .HasForeignKey(dp => dp.ProductoId)//llave que identifica
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pedido>()
            .HasMany(p => p.DetallesPedido) //muschos pedidos un usuario
            .WithOne(dp => dp.Pedido)
            .HasForeignKey(dp => dp.PedidoId)//llave que identifica
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pedido>()
            .Ignore(p => p.Direccion); //Ignorando relacion entre pedido y direccion


            modelBuilder.Entity<Categoria>()
            .HasMany(c => c.Productos) //muschos pedidos un usuario
            .WithOne(p => p.Categoria)
            .HasForeignKey(p => p.CategoriaId)//llave que identifica
            .OnDelete(DeleteBehavior.Restrict);//con restric elimino la categoria pero no los producto asociados a la misma

            






        }
    }
}
