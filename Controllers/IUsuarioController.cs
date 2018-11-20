using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    [ServiceContract]
    public interface IUsuarioBL
    {
        [OperationContract]
        [Description("Servicio REST que permite registrar Usuarios")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "/RegistrarUsuario", BodyStyle = WebMessageBodyStyle.Bare)]
        int NuevoUsuario(UsuarioE usuario);

        [OperationContract]
        int EditarUsuario(UsuarioE usuario);

        [OperationContract]
        int EliminarUsuario(int idUsuario);

        [OperationContract]
        UsuarioE BuscarUsuario(int idUsuario);

        [OperationContract]
        [Description("Servicio REST que permite listar todos Usuarios")]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ListarUsuarios", BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<UsuarioE> MostrarUsuarios();

        [OperationContract]
        UsuarioE AuntentificarUsuario(UsuarioE usuario);
    }
}
