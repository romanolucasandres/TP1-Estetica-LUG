using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DAL
{
    public class AccesoDatos
    {
        // instancio y le paso connectionString
        SqlConnection conexion = new SqlConnection(@"Data Source=LAPTOP-RJIKNK5J\SQLEXPRESS01;Initial Catalog=Estetica;Integrated Security=True");

        public void EjecutarConsulta(string consulta)
        {
            // abre la conexion y crea el objeto Transaction
            conexion.Open();
            SqlTransaction transaccion = conexion.BeginTransaction();

            try
            {
                // crea el comando, le pasa la consulta, conexion y transaccion
                SqlCommand comando = new SqlCommand(consulta, conexion, transaccion);

                comando.ExecuteNonQuery();
                transaccion.Commit();   // si todo sale bien realiza los cambios en la bd

            }
            catch (SqlException ex)
            {
                transaccion.Rollback(); // si algo sale mal vuelve para atras y sin realizar ningun cambio
                throw ex;
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                throw ex;
            }
            finally
            {
                conexion.Close();   // close por si hay algun error
            }
        }

        #region METODOS LEER
        // Leo la BD y  devuelve un DataTable con elementos que se hayan seleccionados en la consulta
        public DataTable Leer(string consulta)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);

                adapter.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return dt;
        }

        // lee varias consultas en la bd y devuelve un DataSet
        public DataSet LeerDS(string consulta)
        {
            DataSet dSet = new DataSet();

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
                adapter.Fill(dSet);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dSet;
        }


        // devuelve un numero
        public int LeerEscalar(string consulta)
        {
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(consulta, conexion);
                return Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }


    
    #endregion METODOS LEER


    

    }

}

