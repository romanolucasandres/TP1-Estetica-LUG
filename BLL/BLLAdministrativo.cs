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
    public class BLLAdministrativo : IAccion<BEAdministrativo>
    {
        //declaro objeto mapper
        MPPAdminitrativo mppAdministrativo;
        public BLLAdministrativo()
        {
            //instancio
            mppAdministrativo = new MPPAdminitrativo();
        }
        public void Alta(BEAdministrativo x)
        {
            mppAdministrativo.Alta(x);
        }

        public void Baja(BEAdministrativo x)
        {
            mppAdministrativo.Baja(x);
        }

        public List<BEAdministrativo> Listar()
        {
            return mppAdministrativo.Listar();
        }

        public void Modifcacion(BEAdministrativo x)
        {
            mppAdministrativo.Modifcacion(x);
        }

        
    }
}
