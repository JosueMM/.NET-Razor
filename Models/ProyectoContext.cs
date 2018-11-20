using Microsoft.EntityFrameworkCore;
using ASPRazor.Models;

namespace ASPRazor.Models
{
    public class ProyectoContext : DbContext
    {
        public ProyectoContext(DbContextOptions<ProyectoContext> options)
                : base(options)
        {
        }

        public DbSet<Models.Carrito> Carrito { get; set; }
        public DbSet<Models.Imagen> Imagen { get; set; }
        public DbSet<Models.Producto> Producto { get; set; }
        public DbSet<Models.Usuario> Usuario { get; set; }
        public DbSet<Models.TipoProducto> TipoProducto { get; set; }
     

    }
}