using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEAdministrativo : BEPersona
    {
        #region Propiedades
        public string Tarea { get; set; }
        public string Contraseña { get; set; }
        #endregion
    }
}
 