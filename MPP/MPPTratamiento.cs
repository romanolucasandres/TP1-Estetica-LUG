using Abstraccion;
using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class MPPTratamiento : IAccion<BETratamiento>
    {
        DAL.AccesoDatos oAccesoDatos;
        //declaro la variable para la query
        string query = null;

        public MPPTratamiento()
        {
            //instancio el acceso
            oAccesoDatos = new DAL.AccesoDatos();
        }
        public void Alta(BETratamiento x)
        {
            query = null;
            query = $"insert into Tratamientos(Nombre,Costo) values ('{x.Nombre}','{x.Costo}')";
            oAccesoDatos.EjecutarConsulta(query);
        }

        public void Baja(BETratamiento x)
        {
            if (!ExisteTratamientoAsociado(x))
            {
                query = null;
                query = $"delete from Tratamientos where Id = '{x.Id}'";
                oAccesoDatos.EjecutarConsulta(string.Format(query));
            }
            else
            {
                throw new Exception("El tratamiento se encuentra asociado a un Turno. Hasta que no se eliminen los turnos con este tratamiento, no se podrá eliminar.");
            }
            
        }

       

        public void Modifcacion(BETratamiento x)
        {
            query = null;
            query = $"update Tratamientos set Nombre = '{x.Nombre}',Costo = '{x.Costo}' ";
            oAccesoDatos.EjecutarConsulta(query);
        }

        public List<BETratamiento> Listar()
        {
            try
            {
                //declaro una lista de tratamientos
                List<BETratamiento> lst = new List<BETratamiento>();
                //accedo a la base
                DataTable dt = oAccesoDatos.Leer("Select * from Tratamientos");

                foreach (DataRow dr in dt.Rows)
                {
                    BETratamiento bETratamiento = new BETratamiento();
                    bETratamiento.Id = Convert.ToInt32(dr["Id"].ToString());
                    bETratamiento.Nombre = dr["Nombre"].ToString();
                    bETratamiento.Costo = Convert.ToDecimal(dr["Costo"].ToString());
                    
                    //agrego a la lista
                    lst.Add(bETratamiento);
                }
                //retorno lista
                return lst;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }

        private bool ExisteTratamientoAsociado(BETratamiento oBEtratamiento)
        {
            oAccesoDatos = new DAL.AccesoDatos();
            query = ("select count(Tratamiento_Id) from Turno where Tratamiento_Id = " + oBEtratamiento.Id + "");
            int resultado = oAccesoDatos.LeerEscalar(query);
            if (resultado > 0)   // si esta asociado, devuelve true
                return true;
            else                 // no esta asociada, devuelve false
                return false;
        }

    }
    
}
