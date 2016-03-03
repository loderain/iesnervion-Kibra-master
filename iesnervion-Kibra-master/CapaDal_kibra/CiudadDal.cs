using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

/* Su tabla es:
    Create Table Ciudades(
	idCiudad integer,
	nombreCiu varchar(80),
	provincia Integer,
	CONSTRAINT PK_Ciudades PRIMARY KEY(idCiudad),	
	constraint FK_Ciudades_Provincias foreign key (provincia) references provincias(idProvincia))
*/
namespace CapaDal_kibra
{
    public class CiudadDal
    {
        /// <summary>
        /// Metodo que devuelve un listado de todas las ciudades. Seguramente no se use, pero por si acaso.
        /// </summary>
        /// <returns>list de ciudades</returns>
        public List<Ciudad> getListaCiudades()
        {
            List<Ciudad> listado = new List<Ciudad>();
            DataBaseHelper helper = new DataBaseHelper();
            SqlCommand comando = new SqlCommand("select idciudad,nombreCiu,provincia from ciudades");
            ProvinciaDal provinciaHelper = new ProvinciaDal();
            DataTable datos = new DataTable();
            try
            {
                datos = helper.getDatos(comando);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            foreach (DataRow row in datos.Rows)
            {
                Provincia p = provinciaHelper.getProvinciaPorId(Convert.ToInt32(row[2]));
                Ciudad c = new Ciudad(Convert.ToInt32(row[0]), row[1].ToString(),p);
                listado.Add(c);
            }

            return listado;
        }

        /// <summary>
        /// Metodo que devuelve un listado de las ciudades que pertenecen a una provincia
        /// </summary>
        /// <param name="p">Provincia por la qe buscar</param>
        /// <returns>List de ciudades filtrada</returns>
        public List<Ciudad> getListaPorProvincia(Int32 p)
        {
            List<Ciudad> listado = new List<Ciudad>();
            DataBaseHelper helper = new DataBaseHelper();
            SqlCommand comando = new SqlCommand("select idciudad,nombreCiu,provincia from ciudades where provincia=@provincia");
            SqlParameter parameter = new SqlParameter("@provincia", p);
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
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            Provincia prov=new ProvinciaDal().getProvinciaPorId(Convert.ToInt32(p));
            foreach (DataRow row in datos.Rows)
            {
                Ciudad c = new Ciudad(Convert.ToInt32(row[0]), row[1].ToString(), prov);
                listado.Add(c);
            }
            return listado;
        }

        /// <summary>
        /// Metodo que devuelve una ciudad dada una id.
        /// </summary>
        /// <param name="idCiudad">id de la ciudad a buscar</param>
        /// <returns>Ciudad buscada.</returns>
        public Ciudad getCiudadPorId(int idCiudad)
        {
            Ciudad c = null;
            DataBaseHelper helper = new DataBaseHelper();
            SqlCommand comando = new SqlCommand("select idCiudad,nombreciu,provincia from ciudades where idciudad=@id");
            SqlParameter parameter = new SqlParameter("@id", idCiudad);
            parameter.DbType = DbType.Int32;
            comando.Parameters.Add(parameter);
            ProvinciaDal provinciaHelper = new ProvinciaDal();
            DataTable datos = new DataTable(); 
            try
            {
                datos = helper.getDatos(comando);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            foreach (DataRow row in datos.Rows)
            {
                Provincia p = provinciaHelper.getProvinciaPorId(Convert.ToInt32(row[2]));
                c = new Ciudad(Convert.ToInt32(row[0]), row[1].ToString(),p);

            }
            return c;
        }

        
    }


}
