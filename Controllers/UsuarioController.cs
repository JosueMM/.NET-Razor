using Entidades;
using Datos;
using System.Collections.Generic;
using System;

namespace Logica
{
    public class UsuarioBL : IUsuarioBL
    {
        public UsuarioE AuntentificarUsuario(UsuarioE usuario)
        {
            if (String.IsNullOrEmpty(usuario.Usuario) || String.IsNullOrEmpty(usuario.Contrasenna))
            {
                throw new Exception("Contraseña y nombre de usuario requeridos");
            }
            UsuarioDA uda = new UsuarioDA();
            return uda.AuntentificarUsuario(usuario);

        }

        public UsuarioE BuscarUsuario(int idUsuario)
        {
            if (idUsuario <= 0)
            {
                throw new Exception("Se debe seleccionar un usuario válido");
            }
            UsuarioDA uda = new UsuarioDA();
            return uda.BuscarUsuario(idUsuario);
        }

        public int EditarUsuario(UsuarioE usuario)
        {
            if (usuario.Id <= 0)
            {
                throw new Exception("Se debe seleccionar un usuario válido");
            }
            UsuarioDA uda = new UsuarioDA();
            return uda.EditarUsuario(usuario);
        }

        public int EliminarUsuario(int idUsuario)
        {
            if (idUsuario <= 0)
            {
                throw new Exception("Se debe seleccionar un usuario");
            }
            UsuarioDA uda = new UsuarioDA();
            return uda.EliminarUsuario(idUsuario);
        }

        public IEnumerable<UsuarioE> MostrarUsuarios()
        {
            UsuarioDA uda = new UsuarioDA();
            return uda.MostrarUsuarios();
        }

        public int NuevoUsuario(UsuarioE usuario)
        {
            if (String.IsNullOrEmpty(usuario.Usuario) || String.IsNullOrEmpty(usuario.Contrasenna))
            {
                throw new Exception("Contraseña y nombre de usuario requeridos");
            }
            UsuarioDA uda = new UsuarioDA();
            return uda.Insertar(usuario);
        }
    }
}
