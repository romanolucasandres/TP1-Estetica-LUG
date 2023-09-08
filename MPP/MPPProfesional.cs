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
    public class MPPProfesional : IAccion<BEProfesional>
    {
        //declaro objeto para acceso a datos
        DAL.AccesoDatos oAccesoDatos;
        //declaro la variable para la query
        string query = null;

        public MPPProfesional()
        {
            //instancio el acceso
            oAccesoDatos = new DAL.AccesoDatos();
        }
        public void Alta(BEProfesional x)
        {
            query = null;
            query = $"insert into Profesionales(DNI,Nombre,Apellido,Telefono,Email,FechaNac,Edad,Titulo) values ('{x.DNI}','{x.Nombre}','{x.Apellido}','{x.Telefono}','{x.Email}','{x.FechaNac.ToShortDateString()}','{x.Edad}','{x.Titulo}')";
            oAccesoDatos.EjecutarConsulta(query);
        }

        public void Baja(BEProfesional x)
        {
            if (!ExisteProfesionalAsociado(x))
            {
                query = null;
                query = $"delete from Profesionales where DNI = {x.DNI}";
                oAccesoDatos.EjecutarConsulta(string.Format(query));
            }
            else
            {
                throw new Exception("El profesional se encuentra asociado en un turno. Si quiere eliminarlo, primero debe eliminar el turno vigente.");
            }
            
        }

       

        public void Modifcacion(BEProfesional x)
        {
            query = null;
            query = $"update Profesionales set DNI = '{x.DNI}', Nombre = '{x.Nombre}', Apellido = '{x.Apellido}', Telefono = '{x.Telefono}', Email = '{x.Email}', FechaNac = '{x.FechaNac.ToShortDateString()}', Edad = '{x.Edad}',  Titulo = '{x.Titulo}'";
            oAccesoDatos.EjecutarConsulta(query);
        }
        public List<BEProfesional> Listar()
        {
            try
            {
                //declaro una lista de Profesionales
                List<BEProfesional> lst = new List<BEProfesional>();
                //accedo a la base
                DataTable dt = oAccesoDatos.Leer("Select * from Profesionales");

                foreach (DataRow dr in dt.Rows)
                {
                    BEProfesional bEProfesional = new BEProfesional();
                    bEProfesional.Id = Convert.ToInt32(dr["Id"].ToString());
                    bEProfesional.DNI = dr["DNI"].ToString();
                    bEProfesional.Nombre = dr["Nombre"].ToString();
                    bEProfesional.Apellido = dr["Apellido"].ToString();
                    bEProfesional.Telefono = dr["Telefono"].ToString();
                    bEProfesional.Email = dr["Email"].ToString();
                    bEProfesional.FechaNac = Convert.ToDateTime(dr["FechaNac"]);
                    bEProfesional.Titulo = dr["Titulo"].ToString();
                    //agrego a la lista
                    lst.Add(bEProfesional);
                }
                //retorno lista
                return lst;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
       

        private bool ExisteProfesionalAsociado(BEProfesional oBEprofesional)
        {
            oAccesoDatos = new DAL.AccesoDatos();
            query = ("select count(Profesional_Id) from Turno where Profesional_Id = " + oBEprofesional.Id + "");
            int resultado = oAccesoDatos.LeerEscalar(query);
            if (resultado > 0)   // si esta asociado, devuelve true
                return true;
            else                 // no esta asociada, devuelve false
                return false;
        }
    }
}
