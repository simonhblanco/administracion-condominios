using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;

namespace RESTTest
{
    [TestClass]
    public class ResidenteTest
    {
        [TestMethod]

            public void CRUDTest()
        {
            // Prueba de creación de Residente vía HTTP POST
            //string postdata = "{\"dni\":\"666\",\"nombres\":\"Cristos\"}"; //JSON
            try
            {
               string postdata = "{\"ApellidoMaterno\":\"cortez\",\"ApellidoPaterno\":\"jesus\",\"Clave\":\"admin\",\"Correo\":\"magda@.com\",\"DNI\":\"666\",\"Edad\":\"25\",\"Nombres\":\"magda\",\"Tipo\":\"R\"}";
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest req = (HttpWebRequest)WebRequest
                    .Create("http://localhost:1424/Residente.svc/Residente");
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
                Assert.AreEqual("cortez", residenteCreado.ApellidoPaterno);
                Assert.AreEqual("jesus", residenteCreado.ApellidoMaterno);
                Assert.AreEqual("admin", residenteCreado.Clave);
                Assert.AreEqual("magda@gmail.com", residenteCreado.Correo);
                Assert.AreEqual("666", residenteCreado.DNI);
                Assert.AreEqual("25", residenteCreado.Edad);
                Assert.AreEqual("magda", residenteCreado.Nombres);
                Assert.AreEqual("R", residenteCreado.Tipo);
            }
            catch (Exception)
            {
                throw;
            }
            }
         }
}
            //***
    //    public void CRUDTest()
    //    {
    //        // Prueba de creación de Residente vía HTTP POST
    //        string postdata = "{\"dni\":\"5\",\"nombres\":\"Juan\"}"; //JSON
    //        byte[] data = Encoding.UTF8.GetBytes(postdata);
    //        HttpWebRequest req = (HttpWebRequest)WebRequest
    //            .Create("http://localhost:1424/Residente.svc/Residente");
    //        req.Method = "POST";
    //        req.ContentLength = data.Length;
    //        req.ContentType = "application/json";
    //        var reqStream = req.GetRequestStream();
    //        reqStream.Write(data, 0, data.Length);
    //        var res = (HttpWebResponse)req.GetResponse();
    //        StreamReader reader = new StreamReader(res.GetResponseStream());
    //        string residenteJson = reader.ReadToEnd();
    //        JavaScripSerializer js = new JavaScripSerializer();
    //        Residente residenteCreado = js.Deserialize<Residente>(residenteJson);
    //        Assert.AreEqual("5", residenteCreado.DNI );
    //        Assert.AreEqual("Juan", residenteCreado.Nombres);

    //        //// Prueba de obtención de alumno vía HTTP GET
    //        //HttpWebRequest req2 = (HttpWebRequest)WebRequest
    //        //    .Create("http://localhost:3181/Alumnos.svc/Alumnos/1");
    //        //req2.Method = "GET";
    //        //HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
    //        //StreamReader reader2 = new StreamReader(res2.GetResponseStream());
    //        //string alumnoJson2 = reader2.ReadToEnd();
    //        //JavaScriptSerializer js2 = new JavaScriptSerializer();
    //        //Alumno alumnoObtenido = js.Deserialize<Alumno>(alumnoJson2);
    //        //Assert.AreEqual("1", alumnoObtenido.Codigo);
    //        //Assert.AreEqual("Juan", alumnoObtenido.Nombre);
    //    }
    //
        

