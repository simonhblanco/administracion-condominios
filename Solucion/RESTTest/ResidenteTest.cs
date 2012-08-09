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
         public void CRUDTest()
         {
            try
            {
                //TEST DE CREACION DE UN NUEVO RESIDENTE
                string postdata = "{\"ApellidoMaterno\":\"Garcia\",\"ApellidoPaterno\":\"Rodriguez\",\"Clave\":\"admin\",\"Correo\":\"cristos@gmail.com\",\"DNI\":\"999\",\"Edad\":\"25\",\"Nombres\":\"Cristos\",\"Tipo\":\"R\"}";
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:1424/Residente.svc/Residente");
                req.Method = "POST";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";
                Stream  reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                HttpWebResponse  res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string residenteJson = reader.ReadToEnd();
                JavaScripSerializer js = new JavaScripSerializer();
                Residente residenteCreado = js.Deserialize<Residente>(residenteJson);
                Assert.AreEqual("Garcia", residenteCreado.ApellidoPaterno);
                Assert.AreEqual("Rodriguez", residenteCreado.ApellidoMaterno);
                Assert.AreEqual("admin", residenteCreado.Clave);
                Assert.AreEqual("cristos@gmail.com", residenteCreado.Correo);
                Assert.AreEqual("999", residenteCreado.DNI);
                Assert.AreEqual("25", residenteCreado.Edad);
                Assert.AreEqual("Cristos", residenteCreado.Nombres);
                Assert.AreEqual("R", residenteCreado.Tipo);

                //TEST DE OBTENCION DE DATOS DE UN RESIDENTE EXISTENTE
                 HttpWebRequest req2 = (HttpWebRequest)WebRequest
                    .Create("http://localhost:1424/Residente.svc/Residente/888");
                req2.Method = "GET";
                HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
                StreamReader reader2 = new StreamReader(res2.GetResponseStream());
                string residenteJson2 = reader2.ReadToEnd();
                JavaScripSerializer js2 = new JavaScripSerializer();
                Residente residenteObtenido = js.Deserialize<Residente>(residenteJson2);
                Assert.AreEqual("cortez", residenteObtenido.ApellidoPaterno);
                Assert.AreEqual("jesus", residenteObtenido.ApellidoMaterno);
                Assert.AreEqual("admin", residenteObtenido.Clave);
                Assert.AreEqual("magda@gmail.com", residenteObtenido.Correo);
                Assert.AreEqual("888", residenteObtenido.DNI);
                Assert.AreEqual("25", residenteObtenido.Edad);
                Assert.AreEqual("magda", residenteObtenido.Nombres);
                Assert.AreEqual("R", residenteObtenido.Tipo);
            }
            catch (Exception)
            {
                //throw;
            }
            }
         }
}
            
  