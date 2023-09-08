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
    public class BLLTratamiento : IAccion<BETratamiento>
    {
        //declaro objeto mapper
        MPPTratamiento mppTratamiento;
        public BLLTratamiento()
        {
            //instancio
            mppTratamiento = new MPPTratamiento();
        }
        public void Alta(BETratamiento x)
        {
            mppTratamiento.Alta(x);
        }

        public void Baja(BETratamiento x)
        {
            mppTratamiento.Baja(x);
        }

        public List<BETratamiento> Listar()
        {
            return mppTratamiento.Listar();
        }    
            public List<BETratamiento> ListarNombres()
        {
            return mppTratamiento.Listar();
        }

        public void Modifcacion(BETratamiento x)
        {
            mppTratamiento.Modifcacion(x);
        }
    }
}
