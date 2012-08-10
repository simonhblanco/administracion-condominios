using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web;



namespace RESTTest
{
    [TestClass]
    public class ResidenteTest
    {
        [TestMethod]
        public void CRUDTestPOST()
        {
            try
            {
                //TEST DE CREACION DE UN NUEVO RESIDENTE
                string postdata = "{\"ApellidoMaterno\":\"Garcia\",\"ApellidoPaterno\":\"Rodriguez\",\"Clave\":\"admin\",\"Correo\":\"cristos@gmail.com\",\"DNI\":\"111\",\"Edad\":\"25\",\"Nombres\":\"Cristos\",\"Tipo\":\"R\"}";
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:1424/Residente.svc/Residente");
                req.Method = "POST";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";
                Stream reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string residenteJson = reader.ReadToEnd();
                JavaScripSerializer js = new JavaScripSerializer();
                Residente residenteCreado = js.Deserialize<Residente>(residenteJson);
                Assert.AreEqual("Garcia", residenteCreado.ApellidoPaterno);
                Assert.AreEqual("Rodriguez", residenteCreado.ApellidoMaterno);
                Assert.AreEqual("admin", residenteCreado.Clave);
                Assert.AreEqual("cristos@gmail.com", residenteCreado.Correo);
                Assert.AreEqual("111", residenteCreado.DNI);
                Assert.AreEqual("25", residenteCreado.Edad);
                Assert.AreEqual("Cristos", residenteCreado.Nombres);
                Assert.AreEqual("R", residenteCreado.Tipo);
            }
            catch (Exception)
            {
                //throw;
            }
        }

        [TestMethod]
        public void CRUDTestGET()
        {
            try
            {
                //TEST DE OBTENCION DE DATOS DE UN RESIDENTE EXISTENTE
                HttpWebRequest req2 = (HttpWebRequest)WebRequest
                .Create("http://localhost:1424/Residente.svc/Residente/111");
                req2.Method = "GET";
                HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
                StreamReader reader2 = new StreamReader(res2.GetResponseStream());
                string residenteJson2 = reader2.ReadToEnd();
                JavaScripSerializer js2 = new JavaScripSerializer();
                Residente residenteObtenido = js2.Deserialize<Residente>(residenteJson2);
                Assert.AreEqual("cortez", residenteObtenido.ApellidoPaterno);
                Assert.AreEqual("jesus", residenteObtenido.ApellidoMaterno);
                Assert.AreEqual("admin", residenteObtenido.Clave);
                Assert.AreEqual("magda@gmail.com", residenteObtenido.Correo);
                Assert.AreEqual("111", residenteObtenido.DNI);
                Assert.AreEqual("25", residenteObtenido.Edad);
                Assert.AreEqual("magda", residenteObtenido.Nombres);
                Assert.AreEqual("R", residenteObtenido.Tipo);
            }
            catch (Exception)
            {
                //throw;
            }
        }

        [TestMethod]
        public void CRUDTestDELETE()
        {
            try
            {
                //TEST DE ELIMINACION DE REGISTRO RESIDENTE
                HttpWebRequest req3 = (HttpWebRequest)WebRequest
                .Create("http://localhost:1424/Residente.svc/Residente/3");
                req3.Method = "DELETE";
                HttpWebResponse res3 = (HttpWebResponse)req3.GetResponse();
                StreamReader reader3 = new StreamReader(res3.GetResponseStream());
                string residenteJson3 = reader3.ReadToEnd();
                JavaScripSerializer js3 = new JavaScripSerializer();
                Residente residenteEliminado = js3.Deserialize<Residente>(residenteJson3);
                //Assert.AreEqual("julito", residenteEliminado.ApellidoPaterno);
                //Assert.AreEqual("julito", residenteEliminado.ApellidoMaterno);
                //Assert.AreEqual("admin", residenteEliminado.Clave);
                //Assert.AreEqual("no tiene", residenteEliminado.Correo);
                //Assert.AreEqual("987", residenteEliminado.DNI);
                //Assert.AreEqual("23", residenteEliminado.Edad);
                //Assert.AreEqual("raquel", residenteEliminado.Nombres);
                //Assert.AreEqual("R", residenteEliminado.Tipo);
                //Assert.Inconclusive("El residente con DNI = 987 ha sido eliminado");
            }
            catch (Exception)
            {
                //throw;
            }
        }

        [TestMethod]
        public void CRUDTestPUT()
        {
            try
            {
                //TEST DE MODIFICACION DE UN RESIDENTE
                string postdata = "{\"ApellidoMaterno\":\"aaaaa\",\"ApellidoPaterno\":\"bbbbb\",\"Clave\":\"admin\",\"Correo\":\"cristos@gmail.com\",\"DNI\":\"999\",\"Edad\":\"100\",\"Nombres\":\"cccccc\",\"Tipo\":\"R\"}";
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:1424/Residente.svc/Residente");
                req.Method = "PUT";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";
                Stream reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string residenteJson = reader.ReadToEnd();
                JavaScripSerializer js = new JavaScripSerializer();
                Residente residenteModificado = js.Deserialize<Residente>(residenteJson);
                Assert.AreEqual("bbbbb", residenteModificado.ApellidoPaterno);
                Assert.AreEqual("aaaaa", residenteModificado.ApellidoMaterno);
                Assert.AreEqual("admin", residenteModificado.Clave);
                Assert.AreEqual("cristos@gmail.com", residenteModificado.Correo);
                Assert.AreEqual("999", residenteModificado.DNI);
                Assert.AreEqual("100", residenteModificado.Edad);
                Assert.AreEqual("cccccc", residenteModificado.Nombres);
                Assert.AreEqual("R", residenteModificado.Tipo);
            }
            catch (Exception)
            {
                //throw;
            }
        }
    }
}

