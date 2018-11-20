using Dapper;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class ProductoDA
    {
        public int Insertar(ProductoE producto)
        {
            int res = 0;
            string sql = "insert into Producto(producto,descripcion, cantidad, idTipoProd, precio, idImagen, activo) values (@pro,@des, @can, @tip, @pre, @ima,@act)";
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracíon.Conexion()))
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction();
                    try
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.Connection = con;
                        cmd.Transaction = trans;

                        ImagenDA idao = new ImagenDA();
                        idao.Insertar(producto.Imagen, cmd);

                        cmd.Parameters.Clear();
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@pro", producto.Producto);
                        cmd.Parameters.AddWithValue("@des", producto.Descripcion);
                        cmd.Parameters.AddWithValue("@can", producto.Cantidad);
                        cmd.Parameters.AddWithValue("@tip", producto.Tipo.Id);
                        cmd.Parameters.AddWithValue("@pre", producto.Precio);
                        cmd.Parameters.AddWithValue("@ima", producto.Imagen.Id);
                        cmd.Parameters.AddWithValue("@act", producto.Activo);
                        res = cmd.ExecuteNonQuery();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                        Console.WriteLine("  Message: {0}", ex.Message);
                        try
                        {
                            trans.Rollback();
                        }
                        catch (Exception ex2)
                        {
                            Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                            Console.WriteLine("  Message: {0}", ex2.Message);
                        }
                    }
                }
            }
            catch (Exception ex3)
            {
                throw new Exception("Error creando un nuevo producto", ex3);
            }
            return res;
        }

        public int EliminarProducto(int id)
        {
            int res = 0;
            string sql = "update Producto set activo = @act where id = @id";
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracíon.Conexion()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@act", 'I');
                    cmd.Parameters.AddWithValue("@id", id);
                    res = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error eliminando un producto", ex);
            }
            return res;
        }

        public int EditarProducto(ProductoE producto)
        {
            int res = 0;
            string sql = "update Producto set producto = @pro, descripcion = @des, cantidad = @can, idTipo = @tip, precio=@pre, idImagen = @ima, activo = @act where id = @id";
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracíon.Conexion()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@pro", producto.Producto);
                    cmd.Parameters.AddWithValue("@des", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@can", producto.Cantidad);
                    cmd.Parameters.AddWithValue("@tip", producto.Tipo.Id);
                    cmd.Parameters.AddWithValue("@pre", producto.Precio);
                    cmd.Parameters.AddWithValue("@ima", producto.Imagen.Id);
                    cmd.Parameters.AddWithValue("@act", producto.Activo);
                    cmd.Parameters.AddWithValue("@id", producto.Id);
                    res = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error modificando un tipo de producto", ex);
            }
            return res;
        }

        public ProductoE BuscarProducto(int idProducto)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(Configuracíon.Conexion()))
                {
                    conexion.Open();
                    var parametros = new DynamicParameters();
                    parametros.Add("@id", idProducto);
                    var producto = conexion.QuerySingle<ProductoE>("select * from Producto where id = @id",
                        param: parametros, commandType: CommandType.Text);
                    return producto;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ProductoE> MostrarProductos(bool todos)
        {
            List<ProductoE> productos = new List<ProductoE>();
            string sql = "select id, producto, descripcion, cantidad, precio, idImagen, idTipoProd, activo from Producto ";
            sql += !todos ? " where activo = 'A' " : "";
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracíon.Conexion()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    ImagenDA ida = new ImagenDA();
                    TipoProductoDA tda = new TipoProductoDA();
                    while (reader.Read())
                    {
                        ProductoE p = new ProductoE
                        {
                            Id = reader.GetInt32(0),
                            Producto = reader.GetString(1),
                            Descripcion = reader.GetString(2),
                            Cantidad = reader.GetInt32(3),
                            Precio = float.Parse(reader[4].ToString()),
                            Imagen = ida.BuscarImagen(reader.GetInt32(5)),
                            Tipo = tda.BuscarTipo(reader.GetInt32(6)),
                            Activo = Char.Parse(reader["Activo"].ToString())

                        };
                        productos.Add(p);
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Problemas al cargar los productos", ex);
            }
            return productos;
        }
    }
}
