using BE;
using MPP;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLLogin
    {


        //declaro objeto mapper
        MPPAdminitrativo mppAdministrativo;
       
        public BLLLogin()
        {
            //instancio
            mppAdministrativo = new MPPAdminitrativo();
        }

        public bool Validacion(BELogin bELogin)
        {
            bool x = false;
            x = mppAdministrativo.ExistePassword(bELogin);
            return x;

        }

       
    }
}
