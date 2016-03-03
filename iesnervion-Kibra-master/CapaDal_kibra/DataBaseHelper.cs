using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using System.Data;

namespace CapaDal_kibra
{

    public class DataBaseHelper{
    

        /// <summary>
        /// Metodo que ejecuta una select sobre la bbdd y devuelve un dataTable con los datos
        /// </summary>
        /// <param name="consulta">Command con la consulta a ejecutar</param>
        /// <returns>datatable con los datos</returns>
        public DataTable getDatos(SqlCommand consulta)
        {
            DataTable datos = new DataTable();
            try
            {
                ConexionBuilder connBuilder = new ConexionBuilder();
                SqlConnection conn = connBuilder.getConexion();

                SqlCommand comando = consulta;
                comando.Connection = conn;
                SqlDataReader Reader = comando.ExecuteReader();


                datos.Load(Reader);

                conn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch(InvalidOperationException ex){
            
                throw ex;
            }

             return datos;
        }


        /// <summary>
        /// Metodo que ejecuta un procedimiento sobre la bbdd. 
        /// </summary>
        /// <pre>El procedimiento debe tener un parametro de salida llamado @res de tipo bit</pre>
        /// <param name="comando">Comando a ejecutar</param>
        /// <returns>True si la operacion fue correcta, false en caso contrario</returns>
        public Boolean executeStoredProcedure(SqlCommand comando)
        {
            Boolean opCorrecta = false;
            try
            {
                ConexionBuilder connBuilder = new ConexionBuilder();
                SqlConnection conn = connBuilder.getConexion();

                SqlParameter outputParam = new SqlParameter("@res", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };

                comando.Parameters.Add(outputParam);
                comando.Connection = conn;
                comando.ExecuteNonQuery();
                Debug.WriteLine(outputParam.Value.ToString());
                opCorrecta = Convert.ToBoolean(outputParam.Value.ToString());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (InvalidOperationException ex)
            {

                throw ex;
            }
            return opCorrecta;

        }

        public int executeStoredProcedureGuardar(SqlCommand comando)
        {
            int opCorrecta = -1;
            try
            {
                ConexionBuilder connBuilder = new ConexionBuilder();
                SqlConnection conn = connBuilder.getConexion();

                SqlParameter outputParam = new SqlParameter("@res", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                comando.Parameters.Add(outputParam);
                comando.Connection = conn;
                comando.ExecuteNonQuery();
                Debug.WriteLine(outputParam.Value.ToString());
                opCorrecta = Convert.ToInt32 (outputParam.Value.ToString());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (InvalidOperationException ex)
            {

                throw ex;
            }
            return opCorrecta;

        }


        public Boolean EjecutaNoQuery(SqlCommand consulta)
        {
            Boolean res = false;
            try
            {
                ConexionBuilder connBuilder = new ConexionBuilder();
                SqlConnection conn = connBuilder.getConexion();

                SqlCommand comando = consulta;
                comando.Connection = conn;
                int filas = comando.ExecuteNonQuery();

                if (filas > 0)
                {
                    res = true;
                }
               

                conn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (InvalidOperationException ex)
            {

                throw ex;
            }

            return res;
        }




    }
}
