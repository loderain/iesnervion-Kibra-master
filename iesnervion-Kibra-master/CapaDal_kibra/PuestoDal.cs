using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
/*
create table Puestos(
	idPuesto integer identity,
	nombrePue varchar(80) not null,
	descPue varchar(150) not null,
	salario money,
	constraint PK_Puestos primary key(idPuesto))
*/

namespace CapaDal_kibra
{
    public class PuestoDal
    {
        /// <summary>
        /// Metodo que devuelve un listado con todos los puestos existentes
        /// </summary>
        /// <returns>list de puestos</returns>
        public List<Puesto> getListaPuestos()
        {
            List<Puesto> listado = new List<Puesto>();
            DataBaseHelper helper = new DataBaseHelper();
            SqlCommand comando = new SqlCommand("select idpuesto,nombrepue,descPue,salario from puestos");
            DataTable datos = helper.getDatos(comando);
            foreach (DataRow row in datos.Rows)
            {
                Puesto p = new Puesto(Convert.ToInt32(row[0]), row[1].ToString(),row[2].ToString(),Convert.ToDouble(row[3].ToString()));
                listado.Add(p);
            }

            return listado;

        }

        /// <summary>
        /// Metodo que devuelve un Puesto dado un id
        /// </summary>
        /// <param name="idPuesto">id del puesto</param>
        /// <returns>Puesto buscado</returns>
        public Puesto getPuestoPorId(Int32 idPuesto)
        {
            Puesto p = null;
            DataBaseHelper helper = new DataBaseHelper();
            SqlCommand comando = new SqlCommand("select idpuesto,nombrepue,descPue,salario from puestos where idpuesto=@id");
            SqlParameter parameter = new SqlParameter("@id", idPuesto);
            parameter.DbType = DbType.Int32;
            comando.Parameters.Add(parameter);
            DataTable datos = helper.getDatos(comando);
            foreach (DataRow row in datos.Rows)
            {
                p = new Puesto(Convert.ToInt32(row[0]), row[1].ToString(), row[2].ToString(), Convert.ToDouble(row[3].ToString()));

            }

            return p;
        }


        /*
          CREATE PROCEDURE insertarPuesto(@nombrePue VARCHAR(80),@descPue VARCHAR(150),@salario MONEY = 0, @res BIT OUTPUT) AS
            BEGIN
	
	            INSERT INTO Puestos(nombrePue,descPue,salario) VALUES (@nombrePue,@descPue,@salario)
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
        /// Metodo que guarda un puesto en la bbdd
        /// </summary>
        /// <param name="puesto">puesto a guardar</param>
        /// <returns>true si la operacion fue correcta, false en caso contrario.</returns>
        public Boolean guardarPuesto(Puesto puesto)
        {
            Boolean insertado = false;
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "insertarPuesto";
            SqlParameter parametro1 = new SqlParameter("@nombrePue", puesto.NombrePue);
            SqlParameter parametro2 = new SqlParameter("@descPue", puesto.DescPue);
            SqlParameter parametro3 = new SqlParameter("@salario", puesto.Salario);

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

            return insertado;

        }


        /*
         CREATE PROCEDURE modificarPuesto (@idPuesto INT, @nombrePue VARCHAR(80),@descPue VARCHAR(150),@salario MONEY=NULL, @res BIT OUTPUT) AS
            BEGIN
	
	            UPDATE Puestos SET nombrePue=@nombrePue,salario=ISNULL(@salario,salario),descPue=@descPue WHERE idPuesto=@idPuesto
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
        /// Metodo que modifica un puesto en la bbdd
        /// </summary>
        /// <param name="puesto">puesto a modificar cn los nuevos datos</param>
        /// <returns>true si la operacion fue correcta, false en caso contrario</returns>
        public Boolean modificarPuesto(Puesto puesto)
        {
            Boolean actualizado = false;
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "modificarPuesto";
            SqlParameter parametro1 = new SqlParameter("@idPuesto", puesto.IdPuesto);
            SqlParameter parametro2 = new SqlParameter("@nombrePue", puesto.NombrePue);
            SqlParameter parametro3 = new SqlParameter("@descPue", puesto.DescPue);
            SqlParameter parametro4 = new SqlParameter("@salario", puesto.Salario);

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
            return actualizado;
        }


        /*
         CREATE PROCEDURE eliminarPuesto (@idPuesto INT, @res BIT OUTPUT) AS
            BEGIN
	            DELETE FROM Puestos WHERE idPuesto=@idPuesto
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
        /// Metodo que elimina un puesto de la bbdd
        /// </summary>
        /// <param name="puesto">Puesto a eliminar</param>
        /// <returns>true si la operacion fue correcta, false en caso contrario</returns>
        public Boolean eliminarPuesto(int id)
        {
            Boolean eliminado = false;
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "eliminarPuesto";
            SqlParameter parametro1 = new SqlParameter("@idPuesto", id);

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
            return eliminado;
        }
          
    }
}
