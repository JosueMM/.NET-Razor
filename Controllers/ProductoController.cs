using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Models;

namespace ASPRazor
{
    public class ProductoController : IProductoController
    {
        public ProductoE BuscarProducto(int idProducto)
        {
            ProductoDA pda = new ProductoDA();
            return pda.BuscarProducto(idProducto);
        }

        public int EditarProducto(ProductoE producto)
        {
            ProductoDA pda = new ProductoDA();
            return pda.EditarProducto(producto);
        }

        public int EliminarProducto(int idProducto)
        {
            ProductoDA pda = new ProductoDA();
            return pda.EliminarProducto(idProducto);
        }

        public List<ProductoE> MostrarProductos(bool todos)
        {
            ProductoDA pda = new ProductoDA();
            return pda.MostrarProductos(todos);
        }

        public IEnumerable<TipoProductoE> MostrarTipos()
        {
            TipoProductoDA pda = new TipoProductoDA();
            return pda.MostrarTipos();
        }

        public int NuevoProducto(ProductoE producto)
        {
            ProductoDA pda = new ProductoDA();
            return pda.Insertar(producto);
        }

    }
}
