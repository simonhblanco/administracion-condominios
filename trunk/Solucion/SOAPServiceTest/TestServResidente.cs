using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SOAPServiceTest
{
    [TestClass]
    public class TestServResidente
    {
        SRResidente.ResidentesClient residenteWS = new SRResidente.ResidentesClient();

        SRResidente.DResidente residente = null;

        [TestMethod]
        public void Test01Crear()
        {
            residente = new SRResidente.DResidente();

            residente.DNI = "07635076";
            residente.ApellidoPaterno = "Valenzuela";
            residente.ApellidoMaterno = "Ñiquen";
            residente.Nombres = "Ander";
            residente.Edad = 30;
            residente.Correo = "abc@campus.edu";
            residente.Clave = "1234";
            residente.Tipo = "R";

            residente = residenteWS.CrearResidente(residente);

            Assert.IsNotNull(residente);
            Assert.IsTrue(residente.Edad > 0);
        }

        [TestMethod]
        public void Test02Obtener()
        {
            residente = new SRResidente.DResidente();

            residente.DNI = "07635076";

            residente = residenteWS.ObtenerResidente(residente.DNI);

            Assert.IsNotNull(residente);
            Assert.AreEqual(residente.DNI, "07635076");
            Assert.IsNotNull(residente.Correo);
        }

        [TestMethod]
        public void Test03Modificar()
        {
            residente = new SRResidente.DResidente();

            residente.DNI = "07635076";
            residente = residenteWS.ObtenerResidente(residente.DNI);

            SRResidente.DResidente residenteOriginal = residenteWS.ObtenerResidente(residente.DNI);

            residente.Nombres = "Anderson";

            SRResidente.DResidente resindeteModificado = residenteWS.ModificarResidente(residente);

            Assert.IsNotNull(resindeteModificado);
            Assert.AreNotEqual(residenteOriginal.Nombres, resindeteModificado.Nombres);
        }

        [TestMethod]
        public void Test04Listar()
        {
            ICollection<SRResidente.DResidente> LDResidente = residenteWS.ListarTodosLosResidentes();
            Assert.IsNotNull(LDResidente);
            Assert.IsTrue(LDResidente.Count > 0);
        }

        [TestMethod]
        public void Test05Eliminar()
        {
            residente = new SRResidente.DResidente();

            residente.DNI = "07635076";

            //Assert.DoesNotThrow(delegate
            //{
            residenteWS.EliminarResidente(residente.DNI);
            //});

            residente = residenteWS.ObtenerResidente(residente.DNI);
            Assert.IsNull(residente);
        }
    }
}
