using Microsoft.EntityFrameworkCore;

namespace ASPRazor.Models
{
    public class ProyectoContext : DbContext
    {
        public ProyectoContext(DbContextOptions<ProyectoContext> options)
                : base(options)
        {
        }

        public DbSet<Carrito> Carrito { get; set; }
        public DbSet<Imagen> Imagen { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoProducto> TipoProducto { get; set; }
     

    }
}