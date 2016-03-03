using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
/*
  Create table Departamentos(
	idDepartamento integer identity,
	nombreDep varchar(80) not null,
	descDep varchar(150) not null,
	telefono varchar(12) not null,
	CONSTRAINT PK_Departamentos PRIMARY KEY (idDepartamento))
*/
namespace CapaDal_kibra
{
    public class DepartamentoDal
    {
        /// <summary>
        /// Metodo que devuelve un listado con todos los departamentos de la bbdd
        /// </summary>
        /// <returns>Lista de departamentos</returns>
        public List<Departamento> getListaDepartamentos()
        {
            List<Departamento> listado = new List<Departamento>();

            DataBaseHelper helper = new DataBaseHelper();
            SqlCommand comando = new SqlCommand("select iddepartamento,nombredep,descdep,telefono from departamentos");
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
                Departamento dep = new Departamento(Convert.ToInt32(row[0]), row[1].ToString(),row[2].ToString(),row[3].ToString());
                listado.Add(dep);
            }

            return listado;
        }

        /// <summary>
        /// Metodo que dado un id departamento, devuelve ese departamento
        /// </summary>
        /// <param name="idDepartamento">id del departamento a buscar</param>
        /// <returns>Departamento buscado</returns>
        public Departamento getDepartamentoPorId(int idDepartamento)
        {
            Departamento departamento = null;
            DataBaseHelper helper = new DataBaseHelper();
            SqlCommand comando = new SqlCommand("select iddepartamento,nombredep,descdep,telefono from departamentos where iddepartamento=@id");
            SqlParameter parameter = new SqlParameter("@id", idDepartamento);
            parameter.DbType = DbType.Int32;
            comando.Parameters.Add(parameter);
            DataTable datos=new DataTable();
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
                departamento = new Departamento(Convert.ToInt32(row[0]), row[1].ToString(), row[2].ToString(), row[3].ToString());

            }

            return departamento;

        }


        /*
          CREATE PROCEDURE insertarDepartamentos(@nombreDep VARCHAR(80),@descDep VARCHAR(150),@telefono VARCHAR(12), @res BIT OUTPUT) AS
            BEGIN
	            --NO DEBERIA DE HABER VALIDACIONES??
	            INSERT INTO Departamentos(nombreDep,descDep,telefono) VALUES (@nombreDep,@descDep,@telefono)
	            IF(@@ROWCOUNT!=0)
	            BEGIN
		            SET @res=1
	            END ELSE
	            BEGIN
		            SET @res=0
	            END
            END
         */
        /// <summary>
        /// Metodo que inserta un departamento.
        /// </summary>
        /// <param name="dep">Departamento a insertar</param>
        /// <returns>True si la operacion fue correcta, false en caso contrario</returns>
        public Boolean guardarDepartamento(Departamento dep)
        {
            Boolean insertado = false;
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "insertarDepartamentos";
            SqlParameter parametro1 = new SqlParameter("@nombreDep", dep.NombreDep);
            SqlParameter parametro2 = new SqlParameter("@descDep", dep.DescDep);
            SqlParameter parametro3 = new SqlParameter("@telefono", dep.Telefono);
            
            comando.Parameters.Add(parametro1);
            comando.Parameters.Add(parametro2);
            comando.Parameters.Add(parametro3);
           

            DataBaseHelper helper = new DataBaseHelper();
            try
            {
                insertado = helper.executeStoredProcedure(comando);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            return insertado;

        }


        /*
          CREATE PROCEDURE modificarDepartamentos (@idDepartamento INT, @nombreDep VARCHAR(80),@descDep VARCHAR(150),@telefono VARCHAR(12), @res BIT OUTPUT) AS
            BEGIN
	            UPDATE Departamentos SET nombreDep=@nombreDep,descDep=@descDep,telefono=@telefono WHERE idDepartamento=@idDepartamento
	            IF(@@ROWCOUNT!=0)
	            BEGIN
		            SET @res=1
	            END ELSE
	            BEGIN
		            SET @res=0
	            END
            END
         */ 
        /// <summary>
        /// Metodo que modifica un departamento.
        /// </summary>
        /// <param name="dep">Departamento a modificar con los nuevos datos</param>
        /// <returns>True si la operacion fue correcta, false en caso contrario</returns>
        public Boolean modificarDepartamento(Departamento dep)
        {
            Boolean actualizado = false;
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "modificarDepartamentos";
            SqlParameter parametro1 = new SqlParameter("@iddepartamento", dep.IdDepartamento);
            SqlParameter parametro2 = new SqlParameter("@nombreDep", dep.NombreDep);
            SqlParameter parametro3 = new SqlParameter("@descDep", dep.DescDep);
            SqlParameter parametro4 = new SqlParameter("@telefono", dep.Telefono);

            comando.Parameters.Add(parametro1);
            comando.Parameters.Add(parametro2);
            comando.Parameters.Add(parametro3);
            comando.Parameters.Add(parametro4);

            DataBaseHelper helper = new DataBaseHelper();
            try
            {
                actualizado = helper.executeStoredProcedure(comando);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            return actualizado;

        }


        /*
          CREATE PROCEDURE eliminarDepartamentos (@idDepartamento INT, @res BIT OUTPUT) AS
            BEGIN
	            DELETE FROM Departamentos WHERE idDepartamento=@idDepartamento
	            IF(@@ROWCOUNT!=0)
	            BEGIN
		            SET @res=1
	            END ELSE
	            BEGIN
		            SET @res=0
	            END
            END
            GO
         */
        /// <summary>
        /// Metodo que elimina un departamento
        /// </summary>
        /// <param name="dep">departamento a eliminar</param>
        /// <returns>True si la operacion fue correcta, false en caso contrario</returns>
        public Boolean eliminarDepartamento(int dep)
        {
            Boolean eliminado = false;
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "eliminarDepartamentos";
            SqlParameter parametro1 = new SqlParameter("@iddepartamento", dep);
            
            comando.Parameters.Add(parametro1);
            
            DataBaseHelper helper = new DataBaseHelper();
            try
            {
                eliminado = helper.executeStoredProcedure(comando);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            return eliminado;
        }

    }
}
