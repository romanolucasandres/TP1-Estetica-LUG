using Abstraccion;
using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLTurno : IAccion<BETurno>
    {
        //declaro objeto mapper
        MPPTurno mppTurno;
        public BLLTurno()
        {
            //instancio
            mppTurno = new MPPTurno();
        }
        public void Alta(BETurno x)
        {
           mppTurno.Alta(x);
        }

        public void Baja(BETurno x)
        {
            mppTurno.Baja(x);        }

        public List<BETurno> Listar()
        {
            return mppTurno.Listar();   
        }

        public void Modifcacion(BETurno x)
        {
            mppTurno.Modifcacion(x);
        }
    }
}
