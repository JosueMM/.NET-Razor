using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Entidades;

namespace Datos
{
    public class ImagenDA
    {
        public void Insertar(ImagenE imagen, SqlCommand cmd)
        {
            try
            {
                cmd.CommandText = "insert into Imagen(imagen, activo) values (@ima, @act);select Scope_Identity()";
                cmd.Parameters.AddWithValue("@ima", imagen.Imagen);
                cmd.Parameters.AddWithValue("@act", 'A');
                object obj = cmd.ExecuteScalar();
                imagen.Id = Int32.Parse(obj.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Problemas al insertar la imagen", ex);
            }
        }

        public ImagenE BuscarImagen(int idTipo)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(Configuracíon.Conexion()))
                {
                    conexion.Open();
                    var parametros = new DynamicParameters();
                    parametros.Add("@id", idTipo);
                    var img = conexion.QuerySingle<ImagenE>("select * from Imagen where id = @id",
                        param: parametros, commandType: CommandType.Text);
                    return img;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
