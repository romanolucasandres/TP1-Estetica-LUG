using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BETratamiento:Entidad
    {
        #region Propiedades
        public string Nombre { get; set; }

        public decimal Costo { get; set; }
        #endregion

        #region Constructores
        // En el caso de que se lo llame, las propiedades se cargan de forma manual despues de instanciar el objeto
        public BETratamiento() { }

        public BETratamiento(int id,string nombre, decimal costo) 
        {
            Id = id;
            Nombre = nombre;
            Costo = costo;
        }
        public BETratamiento(string nom)
        {

            Nombre = nom;
        }
        #endregion constructores sobrecargados





        // override a ToString para poder mostrar el Tratamiento en dgv
        public override string ToString()
        {
            return Nombre;
        }
    }
}
