using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WSDL.Model;

namespace WSDL.WebService
{
    /// <summary>
    /// Descripción breve de WSPersona
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSPersona : System.Web.Services.WebService
    {
        int id;
        static List<Persona> lP;
        Persona oPer;
        public WSPersona()
        {
            lP = new List<Persona>();
            SetPersonas();
            id = lP.Count();
        }
        [WebMethod]
        public List<Persona> GetAll()
        {
            return lP;
        }
        [WebMethod]
        public Persona GetById(int id)
        {
            return lP[id];
        }
        [WebMethod]
        public List<Persona> Add(String nombre,String apellido)
        {
            oPer = new Persona
            {
                id = id,
                nombre = nombre,
                Apellido = apellido
            };
            lP.Add(oPer);
            id++;
            return lP;
        }
        [WebMethod]
        public List<Persona> Delete(int id)
        {
            lP.RemoveAt(id);
            return lP;
        }
        [WebMethod]
        public List<Persona> Update(int id,String nombre,String apellido)
        {
            int index = lP.FindIndex(p => p.id.Equals(id));
            oPer = lP[index];
            oPer.nombre = nombre;
            oPer.Apellido = apellido;
            lP[index] = oPer;
            return lP;
        }
        public void SetPersonas()
        {
            oPer = new Persona
            {
                id = 0,
                nombre = "Karla",
                Apellido = "Pacheco"
            };
            lP.Add(oPer);
            oPer = new Persona
            {
                id = 1,
                nombre = "Tatiana",
                Apellido = "Pacheco"
            };
            lP.Add(oPer);
        }
        
    }
}
