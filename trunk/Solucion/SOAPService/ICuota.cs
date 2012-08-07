using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SOAPService.Dominio;

namespace SOAPService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICuota" in both code and config file together.
    [ServiceContract]
    public interface ICuota
    {
        [OperationContract]
        DCuota CrearCuota(DCuota dcuota);

        [OperationContract]
        DCuota ObtenerCuota(int idcuota);

        [OperationContract]
        DCuota ModificarCuota(DCuota dcuota);

        [OperationContract]
        void EliminarCuota(int idcuota);

        [OperationContract]
        List<DCuota> ListarCuotas();
    }
}
