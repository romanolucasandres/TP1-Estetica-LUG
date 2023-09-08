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
    public class BLLProfesional : IAccion<BEProfesional>
    {
        //declaro objeto mapper
        MPPProfesional mppAdministrativo;
        public BLLProfesional()
        {
            //instancio
            mppAdministrativo = new MPPProfesional();
        }
        public void Alta(BEProfesional x)
        {
            mppAdministrativo.Alta(x);
        }

        public void Baja(BEProfesional x)
        {
            mppAdministrativo.Baja(x);
        }

        public List<BEProfesional> Listar()
        {
            return mppAdministrativo.Listar();
        }

        public void Modifcacion(BEProfesional x)
        {
            mppAdministrativo.Modifcacion(x);
        }
    }
}
