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
    public class MPPCliente : IAccion<BECliente>
    {
        //declaro objeto para acceso a datos
        DAL.AccesoDatos oAccesoDatos;
        //declaro la variable para la query
        string query = null;

        public MPPCliente()
        {
            //instancio el acceso
            oAccesoDatos = new DAL.AccesoDatos();
        }
        #region ABM
        public void Alta(BECliente x)
        {
            query = null;
            query = $"insert into Clientes(DNI,Nombre,Apellido,Telefono,Email,FechaNac,Edad,NroCliente,Direccion) values ('{x.DNI}','{x.Nombre}','{x.Apellido}','{x.Telefono}','{x.Email}','{x.FechaNac.ToShortDateString()}','{x.Edad}','{x.NroCliente}','{x.Direccion}')";
            oAccesoDatos.EjecutarConsulta(query);
        }

        public void Baja(BECliente x)
        {
            if (!ExisteClienteAsociado(x))
            {
                query = null;
                query = $"delete from Clientes where Id = {x.Id}";
                oAccesoDatos.EjecutarConsulta(string.Format(query));

            }
            else
            {
                throw new Exception($"El cliente se encuentra en un turno reservado. Por favor, elimine el truno reservado por el cliente {x.Apellido} y vuelva a intentarlo.");
            }
        }
        public void Modifcacion(BECliente x)
        {
            query = null;
            query = $"update Clientes set DNI = '{x.DNI}', Nombre = '{x.Nombre}', Apellido = '{x.Apellido}', Telefono = '{x.Telefono}', Email = '{x.Email}', FechaNac = '{x.FechaNac.ToShortDateString()}', Edad = '{x.Edad}', NroCliente = '{x.NroCliente}', Direccion = '{x.Direccion}' where Id='{x.Id}'";
            oAccesoDatos.EjecutarConsulta(query);
        }

        #endregion

        #region METODOS
        public List<BECliente> Listar()
        {
            try
            {
                //declaro una lista de Clientes
                List<BECliente> lst = new List<BECliente>();
                //accedo a la base
                DataTable dt = oAccesoDatos.Leer("Select * from Clientes");

                foreach (DataRow dr in dt.Rows)
                {
                    BECliente bECliente = new BECliente();
                    bECliente.Id = Convert.ToInt32(dr["Id"].ToString());
                    bECliente.DNI = dr["DNI"].ToString();
                    bECliente.Nombre = dr["Nombre"].ToString();
                    bECliente.Apellido = dr["Apellido"].ToString();
                    bECliente.Telefono = dr["Telefono"].ToString();
                    bECliente.Email = dr["Email"].ToString();
                    bECliente.FechaNac = Convert.ToDateTime(dr["FechaNac"]);
                    bECliente.Edad = Convert.ToInt32(dr["Edad"].ToString());
                    bECliente.NroCliente = Convert.ToInt32(dr["NroCliente"].ToString());
                    bECliente.Direccion = dr["Direccion"].ToString();

                  
                    //agrego a la lista
                    lst.Add(bECliente);
                }
                //retorno lista
                return lst;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }
        public List<BECliente> ListarTodo()
        {
            try
            {
                DataSet ds;
                oAccesoDatos= new DAL.AccesoDatos();
                //declaro una lista de Clientes
                List<BECliente> lst = new List<BECliente>();
                //accedo a la base
                ds = oAccesoDatos.LeerDS("Select * from Clientes");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    BECliente bECliente = new BECliente();
                    bECliente.Id = Convert.ToInt32(dr["Id"].ToString());
                    bECliente.DNI = dr["DNI"].ToString();
                    bECliente.Nombre = dr["Nombre"].ToString();
                    bECliente.Apellido = dr["Apellido"].ToString();
                    bECliente.Telefono = dr["Telefono"].ToString();
                    bECliente.Email = dr["Email"].ToString();
                    bECliente.FechaNac = Convert.ToDateTime(dr["FechaNac"].ToString());
                    bECliente.Edad = Convert.ToInt32(dr["Edad"].ToString());
                    bECliente.NroCliente = Convert.ToInt32(dr["NroCliente"].ToString());
                    bECliente.Direccion = dr["Direccion"].ToString();

                    string c2 = $"select * from Turnos where Cliente_Id = {bECliente.Id}";
                    //string c2 = $"select Turnos.Id, Clientes.NroCliente as Cliente, Profesionales.Apellido as Profesional, Fecha, Hora, Consultorio,Total,Tratamientos.Nombre as " +
                        //$"Tratamiento FROM Turnos,Clientes,Profesionales,Tratamientos,Cliente_Turno where Turnos.Id = Cliente_Turno.Turno_Id and Cliente_Turno.Cliente_id = {bECliente.Id}";
                    //paso consulta 2 para traer los turnos del cliente
                    DataSet ds2 = new DataSet();
                    ds2=oAccesoDatos.LeerDS(c2);
                    List<BETurno> ListaTurno = new List<BETurno>();
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        foreach(DataRow x in ds2.Tables[0].Rows)
                        {
                            BETurno oTurno = new BETurno();
                            oTurno.Id = Convert.ToInt32(x["Id"]);
                            BECliente cliente = new BECliente(Convert.ToInt32(x["Cliente_Id"]));
                            oTurno.Cliente = cliente;
                            BEProfesional prof = new BEProfesional(x["Profesional_Id"].ToString());
                            oTurno.Profesional = prof;

                            oTurno.Fecha = Convert.ToDateTime(x["Fecha"].ToString());
                            oTurno.Hora = x["Hora"].ToString();
                            oTurno.Consultorio = x["Consultorio"].ToString();
                            oTurno.Total = Convert.ToInt32(x["Total"].ToString());
                            BETratamiento trat = new BETratamiento(x["Tratamiento_Id"].ToString());
                            oTurno.Tratamiento = trat;

                            ListaTurno.Add(oTurno);
                        }
                        bECliente.Turnos = ListaTurno;
                    }
                    //agrego a la lista
                    lst.Add(bECliente);
                }
                //retorno lista
                return lst;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }


        private bool ExisteClienteAsociado(BECliente oBEcliente)
        {
            oAccesoDatos = new DAL.AccesoDatos();
            query = ("select count(Cliente_Id) from Turno where Cliente_Id = " + oBEcliente.Id + "");
            int resultado = oAccesoDatos.LeerEscalar(query);
            if (resultado > 0)   // si esta asociado, devuelve true
                return true;
            else                 // no esta asociada, devuelve false
                return false;
        }

    }
    #endregion
}
