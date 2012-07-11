using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SOAPService.Dominio;

namespace SOAPService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IResidente" in both code and config file together.
    [ServiceContract]
    public interface IResidente
    {
        [OperationContract]
        DResidente CrearResidente(DResidente residente);
    }
}
