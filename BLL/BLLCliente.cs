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
    public class BLLCliente : IAccion<BECliente>
    {
        //declaro objeto mapper
        MPPCliente mppCliente;
        public BLLCliente()
        {
            //instancio
            mppCliente = new MPPCliente();
        }
        public void Alta(BECliente x)
        {
            mppCliente.Alta(x);
        }

        public void Baja(BECliente x)
        {
            mppCliente.Baja(x);
        }

        public List<BECliente> Listar()
        {
            return mppCliente.Listar();
        } 
        public List<BECliente> ListarTodo( )
        {
            return mppCliente.ListarTodo();
        }
      

        public void Modifcacion(BECliente x)
        {
            mppCliente.Modifcacion(x);
        }
    }
}
