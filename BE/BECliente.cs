using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BECliente: BEPersona
    {
        #region Propiedades
        private List<BETurno> bTurno;
        public int NroCliente { get; set; }
        public string Direccion { get; set; }
        #endregion
       //relacion 1 a muchos
        public List<BETurno> Turnos { get => bTurno; set=>bTurno=value; }

        public BECliente( int nro)
        {
            
            NroCliente = nro;
        }
        public BECliente() {
            bTurno = new List<BETurno>();
        }

        public override string ToString()
        {
            return NroCliente.ToString() ;
        }
    }
}
