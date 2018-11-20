using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Datos
{
    public class UsuarioDA
    {

        public int Insertar(UsuarioE usuario)
        {
            int res = 0;
            string sql = "insert into Usuario(usuario,nombre, contrasenna, correo, activo, admin) values (@usu, @nom, @con, @cor, @act, @adm)";
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracíon.Conexion()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@usu", usuario.Usuario);
                    cmd.Parameters.AddWithValue("@nom", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@con", usuario.Contrasenna);
                    cmd.Parameters.AddWithValue("@cor", usuario.Correo);
                    cmd.Parameters.AddWithValue("@act", usuario.Activo);
                    cmd.Parameters.AddWithValue("@adm", usuario.Admin);
                    res = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error creando un nuevo usuario", ex);
            }
            return res;
        }

        public int EliminarUsuario(int idUsuario)
        {
            int res = 0;
            string sql = "update usuario set activo = @act where id = @id";
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracíon.Conexion()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@act", 'I');
                    cmd.Parameters.AddWithValue("@id", idUsuario);
                    res = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error elminando el usuario", ex);
            }
            return res;
        }

        public int EditarUsuario(UsuarioE usuario)
        {
            int res = 0;
            string sql = "update usuario set usuario=@usu, nombre=@nom, contrasenna = @con, correo = @cor, activo = @act, admin = @adm where id = @id";
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracíon.Conexion()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@usu", usuario.Usuario);
                    cmd.Parameters.AddWithValue("@nom", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@con", usuario.Contrasenna);
                    cmd.Parameters.AddWithValue("@cor", usuario.Correo);
                    cmd.Parameters.AddWithValue("@act", usuario.Activo);
                    cmd.Parameters.AddWithValue("@adm", usuario.Admin);
                    cmd.Parameters.AddWithValue("@id", usuario.Id);
                    res = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error modificando el usuario", ex);
            }
            return res;
        }

        public UsuarioE BuscarUsuario(int idUsuario)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(Configuracíon.Conexion()))
                {
                    conexion.Open();
                    var parametros = new DynamicParameters();
                    parametros.Add("@id", idUsuario);
                    var usuario = conexion.QuerySingle<UsuarioE>("select * from Usuario where id = @id",
                        param: parametros, commandType: CommandType.Text);
                    return usuario;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public UsuarioE AuntentificarUsuario(UsuarioE usuario)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(Configuracíon.Conexion()))
                {
                    conexion.Open();
                    var parametros = new DynamicParameters();
                    parametros.Add("@usu", usuario.Usuario);
                    parametros.Add("@con", usuario.Contrasenna);
                    var login = conexion.QuerySingle<UsuarioE>("select * from Usuario where usuario = @usu and contrasenna = @con",
                        param: parametros, commandType: CommandType.Text);
                    return login;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<UsuarioE> MostrarUsuarios()
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Configuracíon.Conexion()))
                {
                    con.Open();
                    var usuarios = con.Query<UsuarioE>("select * from Usuario");
                    return usuarios;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}

