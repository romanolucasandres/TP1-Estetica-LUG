using Abstraccion;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MPP
{
    public class MPPTurno : IAccion<BETurno>
    {
        //declaro objeto para acceso a datos
        DAL.AccesoDatos oAccesoDatos;
        //declaro la variable para la query
        string query = null;

        public MPPTurno()
        {
            //instancio el acceso
            oAccesoDatos = new DAL.AccesoDatos();
        }

        public void Alta(BETurno x)
        {
            query = null;
            query = $"insert into Turnos(Cliente_id,Profesional_Id,Fecha,Hora,Consultorio,Total,Tratamiento_Id) values ('{x.Cliente.Id}','{x.Profesional.Id}','{x.Fecha}','{x.Hora}','{x.Consultorio}','{x.Total}','{x.Tratamiento.Id}')";
            oAccesoDatos.EjecutarConsulta(query);
        }

        public void Baja(BETurno x)
        {
            query = null;
            query = $"delete from Turnos where Id = '{x.Id}'";
            oAccesoDatos.EjecutarConsulta(string.Format(query));
        }

       

        public void Modifcacion(BETurno x)
        {
            query = null;
            query = $"update Turnos set Cliente_Id = '{x.Cliente.Id}', Profesional_Id = '{x.Profesional.Id}', Fecha = '{x.Fecha}', Hora = '{x.Hora}', Consultorio = '{x.Consultorio}', Total = '{x.Total}', Tratamiento_Id = '{x.Tratamiento.Id}' ";
            oAccesoDatos.EjecutarConsulta(query);
        }

        public List<BETurno> Listar()
        {
            List<BETurno> listaTurnos = new List<BETurno>();
           
            DataTable dt = oAccesoDatos.Leer("select Turnos.Id, Clientes.NroCliente as Cliente, Profesionales.Apellido as Profesional, Fecha, Hora, Consultorio,Total,Tratamientos.Nombre as Tratamiento FROM Turnos,Clientes,Profesionales,Tratamientos wherex Cliente_Id = Clientes.Id and Profesional_id = Profesionales.Id");


            foreach (DataRow x in dt.Rows)
            {
                BETurno oTurno = new BETurno();
                oTurno.Id = Convert.ToInt32(x["Id"]);
                BECliente cliente = new BECliente(Convert.ToInt32(x["Cliente"]));
                oTurno.Cliente = cliente;
                BEProfesional prof = new BEProfesional(x["Profesional"].ToString());
                oTurno.Profesional = prof;

                oTurno.Fecha = Convert.ToDateTime(x["Fecha"].ToString());
                oTurno.Hora = x["Hora"].ToString();
                oTurno.Consultorio = x["Consultorio"].ToString();
                oTurno.Total = Convert.ToInt32(x["Total"].ToString());
                BETratamiento trat = new BETratamiento(x["Tratamiento"].ToString());
                oTurno.Tratamiento = trat;
                
                listaTurnos.Add(oTurno);


            }

            return listaTurnos;

        }
       
       
    }
}
