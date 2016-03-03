using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
/*
    Create table Empleados(
    idEmpleado integer identity,
    dniEmp varchar(9) Not null,
    nombreEmp varchar(80) not null,
    apellidoEmp varchar(100) not null,
    fechaNac   date not null,
    direccionEmp varchar(150) not null,
    telefonoEmp varchar(12) not null,
    emailEmp varchar(150) not null,
    departamentoEmp integer,
    puestoEmp integer, 
    ciudadEmp integer,
    constraint PK_Empleados primary key(idEmpleado),
	constraint FK_Empleados_Ciudades foreign key (ciudadEmp) references ciudades(idCiudad),
	constraint FK_Empleados_Departamentos foreign key (departamentoEmp) references departamentos(idDepartamento),
	constraint FK_Empleados_Puestos foreign key (puestoEmp) references Puestos(idPuesto)
*/
namespace CapaDal_kibra
{
    public class EmpleadoDal
    {
        /// <summary>
        /// Metodo que devuelve un listado con todos los empleados en la empresa
        /// </summary>
        /// <returns>List de empleados</returns>
        public List<Empleado> getListaEmpleados()
        {
            List<Empleado> listado = new List<Empleado>();
            DataBaseHelper helper = new DataBaseHelper();
            SqlCommand comando = new SqlCommand("select idempleado, dniemp, nombreemp,apellidoemp,fechaNac,direccionEmp,telefonoemp,emailEmp,departamentoemp,puestoemp,ciudademp from empleados");
            CiudadDal ciudadHelper = new CiudadDal();
            DepartamentoDal departamentoHelper = new DepartamentoDal();
            PuestoDal puestoHelper = new PuestoDal();
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
                Ciudad ciu = ciudadHelper.getCiudadPorId(Convert.ToInt32(row[10]));
                Departamento dep = departamentoHelper.getDepartamentoPorId(Convert.ToInt32(row[8]));
                Puesto pues = puestoHelper.getPuestoPorId(Convert.ToInt32(row[9]));
                Empleado emp = new Empleado(Convert.ToInt32(row[0]), 
                                            row[1].ToString(), 
                                            row[2].ToString(), 
                                            row[3].ToString(), 
                                            Convert.ToDateTime(row[4]), 
                                            row[5].ToString(), row[6].ToString(), 
                                            row[7].ToString(),dep,pues,ciu);
                listado.Add(emp);
            }


            return listado;
        }

        /// <summary>
        /// metodo que devuelve un listado de empleados filtrados por puesto
        /// </summary>
        /// <param name="p">Puesto a buscar</param>
        /// <returns>list de empleados filtrado</returns>
        public List<Empleado> getListaEmpleadosPorPuesto(Puesto p)
        {
            List<Empleado> listado = new List<Empleado>();
            DataBaseHelper helper = new DataBaseHelper();
            SqlCommand comando = new SqlCommand("select idempleado, dniemp, nombreemp,apellidoemp,fechaNac,direccionEmp,telefonoemp,emailEmp,departamentoemp,puestoemp,ciudademp from empleados where puestoemp=@idpuesto");
            SqlParameter parameter = new SqlParameter("@idpuesto", p.IdPuesto);
            parameter.DbType = DbType.Int32;
            comando.Parameters.Add(parameter);
            CiudadDal ciudadHelper = new CiudadDal();
            DepartamentoDal departamentoHelper = new DepartamentoDal();
            PuestoDal puestoHelper = new PuestoDal();
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
                Ciudad ciu = ciudadHelper.getCiudadPorId(Convert.ToInt32(row[10]));
                Departamento dep = departamentoHelper.getDepartamentoPorId(Convert.ToInt32(row[8]));
                Puesto pues = puestoHelper.getPuestoPorId(Convert.ToInt32(row[9]));
                Empleado emp = new Empleado(Convert.ToInt32(row[0]),
                                            row[1].ToString(),
                                            row[2].ToString(),
                                            row[3].ToString(),
                                            Convert.ToDateTime(row[4]),
                                            row[5].ToString(), row[6].ToString(),
                                            row[7].ToString(), dep, pues, ciu);
                listado.Add(emp);
            }


            return listado;
        }

        /// <summary>
        /// metodo que devuelve un listado de empleados filtrados por departamento
        /// </summary>
        /// <param name="p">departamento a buscar</param>
        /// <returns>list de empleados filtrado</returns>
        public List<Empleado> getListaEmpleadosPorDepartamento(Departamento d)
        {
            List<Empleado> listado = new List<Empleado>();
            DataBaseHelper helper = new DataBaseHelper();
            SqlCommand comando = new SqlCommand("select idempleado, dniemp, nombreemp,apellidoemp,fechaNac,direccionEmp,telefonoemp,emailEmp,departamentoemp,puestoemp,ciudademp from empleados where departamentoemp=@iddepartamento");
            SqlParameter parameter = new SqlParameter("@iddepartamento", d.IdDepartamento);
            parameter.DbType = DbType.Int32;
            comando.Parameters.Add(parameter);
            CiudadDal ciudadHelper = new CiudadDal();
            DepartamentoDal departamentoHelper = new DepartamentoDal();
            PuestoDal puestoHelper = new PuestoDal();
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
                Ciudad ciu = ciudadHelper.getCiudadPorId(Convert.ToInt32(row[10]));
                Departamento dep = departamentoHelper.getDepartamentoPorId(Convert.ToInt32(row[8]));
                Puesto pues = puestoHelper.getPuestoPorId(Convert.ToInt32(row[9]));
                Empleado emp = new Empleado(Convert.ToInt32(row[0]),
                                            row[1].ToString(),
                                            row[2].ToString(),
                                            row[3].ToString(),
                                            Convert.ToDateTime(row[4]),
                                            row[5].ToString(), row[6].ToString(),
                                            row[7].ToString(), dep, pues, ciu);
                listado.Add(emp);
            }


            return listado;
        }

        /// <summary>
        /// Metodo que dada una id de empleado devuelve el empleado
        /// </summary>
        /// <param name="idEmpleado">id del empleado</param>
        /// <returns>Empleado buscado</returns>
        public Empleado getEmpleadoPorId(int idEmpleado)
        {
            Empleado e = null;
            DataBaseHelper helper = new DataBaseHelper();
            SqlCommand comando = new SqlCommand("select idempleado, dniemp, nombreemp,apellidoemp,fechaNac,direccionEmp,telefonoemp,emailEmp,departamentoemp,puestoemp,ciudademp from empleados where idEmpleado=@id");
            SqlParameter parameter = new SqlParameter("@id", idEmpleado);
            parameter.DbType = DbType.Int32;
            comando.Parameters.Add(parameter);
            CiudadDal ciudadHelper = new CiudadDal();
            DepartamentoDal departamentoHelper = new DepartamentoDal();
            PuestoDal puestoHelper = new PuestoDal();
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
                Ciudad ciu = ciudadHelper.getCiudadPorId(Convert.ToInt32(row[10]));
                Departamento dep = departamentoHelper.getDepartamentoPorId(Convert.ToInt32(row[8]));
                Puesto pues = puestoHelper.getPuestoPorId(Convert.ToInt32(row[9]));
                e = new Empleado(Convert.ToInt32(row[0]),
                                            row[1].ToString(),
                                            row[2].ToString(),
                                            row[3].ToString(),
                                            Convert.ToDateTime(row[4]),
                                            row[5].ToString(), row[6].ToString(),
                                            row[7].ToString(), dep, pues, ciu);
                
            }


            return e;

        }

        /*
         CREATE PROCEDURE insertarEmpleado(@dniEmpl VARCHAR(9),@nombreEmp VARCHAR(80),@apellidoEmp VARCHAR(100),@fechaNac DATE, @direccionEmp VARCHAR(150)
	        ,@telefonoEmp VARCHAR(12),@emailEmp VARCHAR(150),@departamentoEmp INT = NULL, @puestoEmp INT =NULL,@ciudadEmp INT =NULL ,@res BIT OUTPUT) AS
        BEGIN
	
	        INSERT INTO Empleados(dniEmp,nombreEmp,apellidoEmp,fechaNac,direccionEmp,telefonoEmp,emailEmp,departamentoEmp,puestoEmp,ciudadEmp) 
			        VALUES (@dniEmpl,@nombreEmp,@apellidoEmp,@fechaNac,@direccionEmp,@telefonoEmp,@emailEmp,@departamentoEmp,@puestoEmp,@ciudadEmp)
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
        /// Procedimiento que recibe un empleado y lo almacena en la bbdd
        /// </summary>
        /// <param name="e">Empleado a guardar</param>
        /// <returns>True si la operacion fue correcta, false en caso contrario</returns>
        public int guardarEmpleado(Empleado e)
        {
            int id = -1;
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "insertarEmpleado";
            SqlParameter parametro1 = new SqlParameter("@dniEmpl", e.DniEmp);
            SqlParameter parametro2 = new SqlParameter("@nombreemp", e.NombreEmp);
            SqlParameter parametro3 = new SqlParameter("@apellidoemp", e.ApellidoEmp);
            SqlParameter parametro4 = new SqlParameter("@fechanac", e.FechaNac);
            SqlParameter parametro5 = new SqlParameter("@direccionemp", e.DireccionEmp);
            SqlParameter parametro6 = new SqlParameter("@telefonoemp", e.TelefonoEmp);
            SqlParameter parametro7 = new SqlParameter("@emailemp", e.EmailEmp);
            SqlParameter parametro8 = new SqlParameter("@departamentoemp", e.DepartamentoEmp.IdDepartamento);
            SqlParameter parametro9 = new SqlParameter("@puestoemp", e.PuestoEmp.IdPuesto);
            SqlParameter parametro10 = new SqlParameter("@ciudademp", e.CiudadEmp.IdCiudad);

            comando.Parameters.Add(parametro1);
            comando.Parameters.Add(parametro2);
            comando.Parameters.Add(parametro3);
            comando.Parameters.Add(parametro4);
            comando.Parameters.Add(parametro5);
            comando.Parameters.Add(parametro6);
            comando.Parameters.Add(parametro7);
            comando.Parameters.Add(parametro8);
            comando.Parameters.Add(parametro9);
            comando.Parameters.Add(parametro10);


            DataBaseHelper helper = new DataBaseHelper();
            try
            {
                id = helper.executeStoredProcedureGuardar(comando);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            return id;
        }

        /*
         CREATE PROCEDURE modificarEmpleado (@idEmpleado INT, @dniEmpl VARCHAR(9),@nombreEmp VARCHAR(80),@apellidoEmp VARCHAR(100),@fechaNac DATE, @direccionEmp VARCHAR(150)
	        ,@telefonoEmp VARCHAR(12),@emailEmp VARCHAR(150),@departamentoEmp INT = NULL, @puestoEmp INT =NULL,@ciudadEmp INT =NULL ,@res BIT OUTPUT) AS
        BEGIN

	        UPDATE Empleados SET dniEmp=@dniEmpl,nombreEmp=@nombreEmp,apellidoEmp=@apellidoEmp,fechaNac=@fechaNac,direccionEmp=@direccionEmp,
		        telefonoEmp=@telefonoEmp,emailEmp=@emailEmp,departamentoEmp=ISNULL(@departamentoEmp,departamentoEmp),
		        puestoEmp=ISNULL(@puestoEmp,puestoEmp),ciudadEmp=ISNULL(@ciudadEmp,ciudadEmp) WHERE idEmpleado=@idEmpleado

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
        /// Metodo que dado un empleado modiffica sus datos
        /// </summary>
        /// <param name="e">empleado con los datos ya modificados</param>
        /// <returns>True si la operacion fue correcta, false en caso contrario</returns>
        public Boolean modificarEmpleado(Empleado e)
        {
            Boolean actualizado = false;
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "insertarEmpleado";
            SqlParameter parametro1 = new SqlParameter("@idEmpleado", e.IdEmpleado);
            SqlParameter parametro2 = new SqlParameter("@dniEmpl", e.DniEmp);
            SqlParameter parametro3 = new SqlParameter("@nombreemp", e.NombreEmp);
            SqlParameter parametro4 = new SqlParameter("@apellidoemp", e.ApellidoEmp);
            SqlParameter parametro5 = new SqlParameter("@fechanac", e.FechaNac);
            SqlParameter parametro6 = new SqlParameter("@direccionemp", e.DireccionEmp);
            SqlParameter parametro7 = new SqlParameter("@telefonoemp", e.TelefonoEmp);
            SqlParameter parametro8 = new SqlParameter("@emailemp", e.EmailEmp);
            SqlParameter parametro9 = new SqlParameter("@departamentoemp", e.DepartamentoEmp.IdDepartamento);
            SqlParameter parametro10 = new SqlParameter("@puestoemp", e.PuestoEmp.IdPuesto);
            SqlParameter parametro11 = new SqlParameter("@ciudademp", e.CiudadEmp.IdCiudad);

            comando.Parameters.Add(parametro1);
            comando.Parameters.Add(parametro2);
            comando.Parameters.Add(parametro3);
            comando.Parameters.Add(parametro4);
            comando.Parameters.Add(parametro5);
            comando.Parameters.Add(parametro6);
            comando.Parameters.Add(parametro7);
            comando.Parameters.Add(parametro8);
            comando.Parameters.Add(parametro9);
            comando.Parameters.Add(parametro10);
            comando.Parameters.Add(parametro11);

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
         CREATE PROCEDURE eliminarEmpleado (@idEmpleado INT, @res BIT OUTPUT) AS
            BEGIN
	            DELETE FROM Empleados WHERE idEmpleado=@idEmpleado
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
        /// Metodo que elimina un empleado de la bbdd
        /// </summary>
        /// <param name="e">empleado a eliminar</param>
        /// <returns>True si la operacion fue correcta, false en caso contrario</returns>
        public Boolean eliminarEmpleado(Empleado e)
        {
            Boolean eliminado = false;
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "eliminarEmpleado";
            SqlParameter parametro1 = new SqlParameter("@idEmpleado", e.IdEmpleado);

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
