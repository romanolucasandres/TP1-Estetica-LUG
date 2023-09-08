using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraccion
{
    public interface IAccion <T> where T : IEntidad
    {
        List<T> Listar();

        #region Métodos ABM Genéricos

        void Alta(T x);
        void Baja(T x);
        void Modifcacion(T x);
        #endregion
    }
}
