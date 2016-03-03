using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

using System.Diagnostics;
using System.Data;
namespace CapaDal_kibra
{

    /* Su tabla es: 
       Create Table Provincias(
       idProvincia integer,
       nombreProv varchar(80),
       CONSTRAINT PK_Provincias PRIMARY KEY(idProvincia))
     */
    public class ProvinciaDal
    {
        /// <summary>
        /// Metodo que devuelve un listado de todas las provincias
        /// </summary>
        /// <returns>List con todas las provincias</returns>
        public List<Provincia> getListaProvincias()
        {
            List<Provincia> lista = new List<Provincia>();
            DataBaseHelper helper = new DataBaseHelper();
            SqlCommand comando = new SqlCommand("select idprovincia,nombreprov from provincias");
            DataTable datos = new DataTable();
            try
            {
                datos = helper.getDatos(comando);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            foreach (DataRow row in datos.Rows)
            {
               Provincia p=new Provincia(Convert.ToInt32(row[0]),row[1].ToString());
               lista.Add(p);
            }

            return lista;
        }

        /// <summary>
        /// Metodo que devuelve una provincia dada una id
        /// </summary>
        /// <param name="id">id de la provincia</param>
        /// <returns>Provincia buscada</returns>
        public Provincia getProvinciaPorId(Int32 idProvincia)
        {
            Provincia prov = null;
            DataBaseHelper helper = new DataBaseHelper();
            SqlCommand comando = new SqlCommand("select idprovincia,nombreprov from provincias where idprovincia=@id");
            SqlParameter parameter = new SqlParameter("@id", idProvincia);
            parameter.DbType = DbType.Int32;
            comando.Parameters.Add(parameter);
            DataTable datos = new DataTable();
            try
            {
                datos = helper.getDatos(comando);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            foreach (DataRow row in datos.Rows)
            {
                prov= new Provincia(Convert.ToInt32(row[0]), row[1].ToString());
                
            }
            return prov;
        }




    }
}
