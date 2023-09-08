using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPersona :Entidad
    {
        #region Propiedades
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaNac { get; set; }
        public int Edad { get; set; }

        #endregion
        public void CalcularEdad()
        {
            Edad = DateTime.Today.Year - FechaNac.Year;
            if (DateTime.Today.Month < FechaNac.Month)
                Edad -= 1;
            if (DateTime.Today.Month == FechaNac.Month && DateTime.Today.Day < FechaNac.Day)
                Edad -= 1;
        }
    }
}
