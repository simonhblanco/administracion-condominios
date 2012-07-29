using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SOAPService.Dominio;

namespace SOAPService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IViviendas" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IViviendas
    {
        [OperationContract]
        DVivienda CrearVivienda(DVivienda dvivienda);

        [OperationContract]
        DVivienda ObtenerVivienda(int codigo);

        [OperationContract]
        DVivienda ModificarVivienda(DVivienda dvivienda);

        [OperationContract]
        DVivienda EliminarVivienda(DVivienda dvivienda);

        [OperationContract]
        ICollection<DVivienda> ListarTodosLasViviendas();  
    }
}
