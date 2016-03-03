using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CapaDal_kibra
{
    public class ConexionBuilder
    {
        public String server = "localhost";
        public String bbdd = "proyecto_kibra";
        public String usuario = "kibra";
        public String pass = "1234";

        public ConexionBuilder() { }

        /// <summary>
        /// Metodo que devuelve una conexion a la bbdd.
        /// </summary>
        /// <returns></returns>
        public SqlConnection getConexion()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString="Data Source="+server+";Initial Catalog="+bbdd+";user id="+usuario+";password="+pass;
            try
            {
                conexion.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return conexion;
        }


    }
}
