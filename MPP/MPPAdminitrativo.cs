using Abstraccion;
using BE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class MPPAdminitrativo : IAccion<BEAdministrativo>
    {
        //declaro objeto para acceso a datos
        DAL.AccesoDatos oAccesoDatos;
        //declaro la variable para la query
        string query = null;
    

        public MPPAdminitrativo()
        {
            //instancio el acceso
            oAccesoDatos = new DAL.AccesoDatos();
        }
        #region ABM
        public void Alta(BEAdministrativo x)
        {
            query = null;
            query = $"insert into Administrativos(DNI,Nombre,Apellido,Telefono,Email,Contraseña,FechaNac,Edad,Tarea) values ('{x.DNI}','{x.Nombre}','{x.Apellido}','{x.Telefono}','{x.Email}','{x.Contraseña}','{x.FechaNac.ToString("yyyy-MM-dd")}','{x.Edad}','{x.Tarea}')";
            oAccesoDatos.EjecutarConsulta(query);
        }

        public void Baja(BEAdministrativo x)
        {
            query = null;
            query = $"delete from Administrativos where DNI = '{x.DNI}'";
            oAccesoDatos.EjecutarConsulta(string.Format(query));
        }

      

        public void Modifcacion(BEAdministrativo x)
        {
            query = null;
            query = $"update Administrativos set DNI = '{x.DNI}', Nombre = '{x.Nombre}', Apellido = '{x.Apellido}', Telefono = '{x.Telefono}', Email = '{x.Email}', Contraseña = '{x.Contraseña}', FechaNac = '{x.FechaNac.ToString("yyyy-MM-dd")}', Edad = '{x.Edad}', Tarea = '{x.Tarea}'";
            oAccesoDatos.EjecutarConsulta(query);
        }
        #endregion

        #region Metodos
        public List<BEAdministrativo> Listar()
        {
            try
            {
                //declaro una lista de administrativos
                List<BEAdministrativo> lst = new List<BEAdministrativo>();
                //accedo a la base
                DataTable dt = oAccesoDatos.Leer("Select * from Administrativos");

                foreach (DataRow dr in dt.Rows)
                {
                    BEAdministrativo bEAdministrativo = new BEAdministrativo();
                    bEAdministrativo.Id = Convert.ToInt32(dr["Id"].ToString());
                    bEAdministrativo.DNI = dr["DNI"].ToString();
                    bEAdministrativo.Nombre = dr["Nombre"].ToString();
                    bEAdministrativo.Apellido = dr["Apellido"].ToString();
                    bEAdministrativo.Telefono = dr["Telefono"].ToString();
                    bEAdministrativo.Email = dr["Email"].ToString();
                    bEAdministrativo.Contraseña = dr["Contraseña"].ToString();
                    bEAdministrativo.FechaNac = Convert.ToDateTime(dr["FechaNac"]);
                    bEAdministrativo.Edad = Convert.ToInt32(dr["Edad"].ToString());
                    bEAdministrativo.Tarea = dr["Tarea"].ToString();
                    //agrego a la lista
                    lst.Add(bEAdministrativo);
                }
                //retorno lista
                return lst;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
           
        }

       
       
        public bool ExistePassword (BELogin oBELogin)
        {
            oAccesoDatos = new DAL.AccesoDatos();
            query = ($"select count(Contraseña) from Administrativos where Contraseña =  '{oBELogin.Password}' and Email = '{oBELogin.Email}'");
            int resultado = oAccesoDatos.LeerEscalar(query);
            if (resultado > 0)   // si existe, devuelve true
                return true;
            else                 // no esta el email, devuelve false
                return false;
        }
        #endregion

    }
}
