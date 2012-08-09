using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SOAPService.Dominio;

namespace SOAPService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ITransaccionesPagos" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ITransaccionesPagos
    {
        [OperationContract]
        DTransaccionPago CrearTransaccion(DTransaccionPago dTransaccionPago);

        [OperationContract]
        DTransaccionPago ObtenerTransaccion(int idtransaccionpago);

        [OperationContract]
        DTransaccionPago ModificarTransaccion(DTransaccionPago dTransaccionPago);

        [OperationContract]
        void EliminarTransaccion(int idtransaccionpago);
    }
}
