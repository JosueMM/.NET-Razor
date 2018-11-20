using Dapper;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class TipoProductoDA
    {

        public int Insertar(TipoProductoE tipo)
        {
            int res = 0;
            string sql = "insert into TipoProducto(tipo,activo) values (@tip, @act)";
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracíon.Conexion()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@tip", tipo.Tipo);
                    cmd.Parameters.AddWithValue("@act", tipo.Activo);
                    res = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error creando un nuevo tipo de producto", ex);
            }
            return res;
        }

        public int EliminarTipo(int idTipo)
        {
            int res = 0;
            string sql = "update TipoProducto set activo = @act where id = @id";
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracíon.Conexion()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@act", 'I');
                    cmd.Parameters.AddWithValue("@id", idTipo);
                    res = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error eliminando el tipo de producto", ex);
            }
            return res;
        }

        public int EditarUsuario(TipoProductoE tipo)
        {
            int res = 0;
            string sql = "update TipoProducto set tipo = @tip, activo = @act where id = @id";
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracíon.Conexion()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@tip", tipo.Tipo);
                    cmd.Parameters.AddWithValue("@act", tipo.Activo);
                    cmd.Parameters.AddWithValue("@id", tipo.Id);
                    res = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error modificando un tipo de producto", ex);
            }
            return res;
        }

        public TipoProductoE BuscarTipo(int idTipo)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(Configuracíon.Conexion()))
                {
                    conexion.Open();
                    var parametros = new DynamicParameters();
                    parametros.Add("@id", idTipo);
                    var tipo = conexion.QuerySingle<TipoProductoE>("select * from TipoProducto where id = @id",
                        param: parametros, commandType: CommandType.Text);
                    return tipo;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<TipoProductoE> MostrarTipos()
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Configuracíon.Conexion()))
                {
                    con.Open();
                    var tipos = con.Query<TipoProductoE>("select * from TipoProducto");
                    return tipos;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
