using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using RESTService.Dominio;

namespace RESTService
{
    [ServiceContract]
    public interface IResidente
    {
        //
        [OperationContract]
        [WebInvoke(Method="POST", UriTemplate="Residente", ResponseFormat=WebMessageFormat.Json)]
        DResidente CrearResidente(DResidente residenteACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Residente/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        DResidente ObtenerResidente(string codigo);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "nombres/{nombre}/edad/{edad}/codigo/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        DResidente ModificarResidente(string nombre, string edad, string codigo);
        //DResidente ModificarResidente(DResidente residenteAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Residente/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        DResidente EliminarResidente(string codigo);

        [OperationContract]
        ICollection<DResidente> ListarTodosLosResidentes();
    }

}
