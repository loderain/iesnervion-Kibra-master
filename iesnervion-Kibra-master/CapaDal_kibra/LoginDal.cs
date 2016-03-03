using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
/*
Create table [Login](
	idLogin integer identity,
	usuario varchar(30) not null,
	passwd varchar(30) not null,
	ultimoAcceso date,
	empleado integer,
	CONSTRAINT PK_Login PRIMARY KEY (idLogin),
	constraint FK_login_empleados foreign key (empleado) references empleados(idEmpleado))
 * 
 * 
 * 
  Create table Login_Privilegios(
	idLogin integer identity,
	idPrivilegio integer,
	fechaAsignado date,
	CONSTRAINT PK_Login_Privilegios PRIMARY KEY (idLogin,idPrivilegio),
	constraint FK_Login_Empleados_Login foreign key (idLogin) references [login](idLogin),
	constraint FK_login_Privilegios_Privilegios foreign key (idPrivilegio) references privilegios(idPrivilegio))
*/
namespace CapaDal_kibra
{
    public class LoginDal
    {
        /// <summary>
        /// Obtiene un listado de todos los logins de la bbdd. Quiza no se use pero por si acaso.
        /// </summary>
        /// <returns></returns>
        public List<Login> getListaLogins()
        {
            List<Login> listado = new List<Login>();
            DataBaseHelper helper = new DataBaseHelper();
            SqlCommand comando = new SqlCommand("select idlogin,usuario,passwd,ultimoAcceso,empleado from login");
            EmpleadoDal empleadoHelper = new EmpleadoDal();
            PrivilegioDal privilegioHelper = new PrivilegioDal();
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
                Empleado e = empleadoHelper.getEmpleadoPorId(Convert.ToInt32(row[4]));
                SqlCommand comandoPriv = new SqlCommand("select idPrivilegio from login_privilegios where idlogin=@login");
                SqlParameter paramPriv = new SqlParameter("@login", Convert.ToInt32(row[0]));
                comandoPriv.Parameters.Add(paramPriv);
                DataTable privs = helper.getDatos(comandoPriv);
                List<Privilegio> listaPrivilegios = new List<Privilegio>();
                foreach (DataRow rowPriv in privs.Rows)
                {
                    Privilegio privilegio = privilegioHelper.getPrivilegioPorId(Convert.ToInt32(rowPriv[0]));
                    listaPrivilegios.Add(privilegio);
                }

                Login l = new Login(Convert.ToInt32(row[0]), row[1].ToString(),row[2].ToString(),Convert.ToDateTime(row[3]), e);
                l.Privilegios = listaPrivilegios;
                listado.Add(l);
            }

            return listado;
        }

        /// <summary>
        /// Metodo que obtiene el login de un empleado pasado por parametro
        /// </summary>
        /// <param name="e">Empleado cuyo login buscaremos.</param>
        /// <returns>Login buscado</returns>
        public Login getLoginPorEmpleado(Empleado e)
        {
            Login l = null;
            DataBaseHelper helper = new DataBaseHelper();
            SqlCommand comando = new SqlCommand("select idlogin,usuario,passwd,ultimoAcceso,empleado from login where empleado=@empleado");
            SqlParameter parametro1 = new SqlParameter("@empleado",e.IdEmpleado);
                    
            comando.Parameters.Add(parametro1);
            
            
            PrivilegioDal privilegioHelper = new PrivilegioDal();
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
                SqlCommand comandoPriv = new SqlCommand("select idPrivilegio from login_privilegios where idlogin=@login");
                SqlParameter paramPriv = new SqlParameter("@login", Convert.ToInt32(row[0]));
                
                comandoPriv.Parameters.Add(paramPriv);
                DataTable privs = helper.getDatos(comandoPriv);
                List<Privilegio> listaPrivilegios = new List<Privilegio>();
                foreach (DataRow rowPriv in privs.Rows)
                {
                    Privilegio privilegio = privilegioHelper.getPrivilegioPorId(Convert.ToInt32(rowPriv[0]));
                    listaPrivilegios.Add(privilegio);
                    Debug.WriteLine(privilegio.NombrePriv);
                }
                l = new Login(Convert.ToInt32(row[0]), row[1].ToString(), row[2].ToString(), Convert.ToDateTime(row[3]), e);

                l.Privilegios = listaPrivilegios;
            }

            return l;
        }


        public Login getLogin(String usuario, String pass)
        {
            
            Login l = null;
            DataBaseHelper helper = new DataBaseHelper();
            SqlCommand comando = new SqlCommand("select idlogin,usuario,passwd,ultimoAcceso,empleado from login where usuario=@usuario and passwd=CONVERT(NVARCHAR(30),HASHBYTES('MD5',@passwd),2)");
            SqlParameter parametro1 = new SqlParameter("@usuario", usuario);
            SqlParameter parametro2 = new SqlParameter("@passwd",pass);
            parametro2.SqlDbType = SqlDbType.VarChar;
            comando.Parameters.Add(parametro1);
            comando.Parameters.Add(parametro2);
            EmpleadoDal empleadoHelper = new EmpleadoDal();
            PrivilegioDal privilegioHelper = new PrivilegioDal();
            DataTable datos = new DataTable();
            try
            {
                
                datos = helper.getDatos(comando);
                Debug.WriteLine(datos.Rows.Count);
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
                Empleado e = empleadoHelper.getEmpleadoPorId(Convert.ToInt32(row[4]));
                Debug.WriteLine(e.NombreEmp);
                SqlCommand comandoPriv = new SqlCommand("select idPrivilegio from login_privilegios where idlogin=@login");
                SqlParameter paramPriv = new SqlParameter("@login", Convert.ToInt32(row[0]));
                Debug.WriteLine("login "+Convert.ToInt32(row[0]));
                comandoPriv.Parameters.Add(paramPriv);
                DataTable privs = helper.getDatos(comandoPriv);
                List<Privilegio> listaPrivilegios = new List<Privilegio>();
                foreach (DataRow rowPriv in privs.Rows)
                {
                    Privilegio privilegio = privilegioHelper.getPrivilegioPorId(Convert.ToInt32(rowPriv[0]));
                    listaPrivilegios.Add(privilegio);
                    Debug.WriteLine(privilegio.NombrePriv);
                }
               l = new Login(Convert.ToInt32(row[0]), row[1].ToString(), row[2].ToString(), Convert.ToDateTime(row[3]), e);
               
               l.Privilegios = listaPrivilegios;
            }

            return l;

        }

        /*
         CREATE PROCEDURE insertarLogin(@usuario VARCHAR(30),@passwd VARCHAR(30),@ultimoAcceso DATE='01-01-0001',@empleado INT=NULL, @res BIT OUTPUT) AS
            BEGIN

	            INSERT INTO Login(usuario,passwd,ultimoAcceso,empleado) VALUES (@usuario,CONVERT(NVARCHAR(30),HASHBYTES('MD5',@passwd),2),@ultimoAcceso,@empleado)
	            IF(@@ROWCOUNT!=0)
	            BEGIN
		            SET @res=1
	            END ELSE
	            BEGIN
		            SET @res=0
	            END
            END
         */ 

        public Boolean guardarLogin(Login l)
        {
            Boolean insertado = false;
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "insertarLogin";
            SqlParameter parametro1 = new SqlParameter("@usuario", l.Usuario);
            SqlParameter parametro2 = new SqlParameter("@passwd", l.Passwd);
            SqlParameter parametro3 = new SqlParameter("@ultimoAcceso", l.UltimoAcceso);
            SqlParameter parametro4 = new SqlParameter("@empleado", l.Empleado.IdEmpleado);
            comando.Parameters.Add(parametro1);
            comando.Parameters.Add(parametro2);
            comando.Parameters.Add(parametro3);
            comando.Parameters.Add(parametro4);
           
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
         CREATE PROCEDURE modificarLogin (@idLogin INT, @usuario VARCHAR(30),@passwd VARCHAR(30),@ultimoAcceso DATE=NULL,@empleado INT=NULL, @res BIT OUTPUT) AS
            BEGIN
	            UPDATE Login SET usuario=@usuario,passwd=CONVERT(NVARCHAR(30),HASHBYTES('MD5',@passwd),2),ultimoAcceso=ISNULL(@ultimoAcceso,ultimoAcceso),empleado=ISNULL(@empleado,empleado) WHERE idLogin=@idLogin
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
        public Boolean modificarLogin(Login l)
        {
            Boolean actualizado = false;
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "modificarLogin ";
            SqlParameter parametro1 = new SqlParameter("@idlogin", l.IdLogin);
            SqlParameter parametro2 = new SqlParameter("@usuario", l.Usuario);
            SqlParameter parametro3 = new SqlParameter("@passwd", l.Passwd);
            SqlParameter parametro4 = new SqlParameter("@ultimoAcceso", DateTime.Now);
            SqlParameter parametro5 = new SqlParameter("@empleado", l.Empleado);


            comando.Parameters.Add(parametro1);
            comando.Parameters.Add(parametro2);
            comando.Parameters.Add(parametro3);
            comando.Parameters.Add(parametro4);
            comando.Parameters.Add(parametro5);


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
         CREATE PROCEDURE eliminarLogin (@idLogin INT, @res BIT OUTPUT) AS
        BEGIN
	        DELETE FROM Login WHERE idLogin=@idLogin
	        IF(@@ROWCOUNT!=0)
	        BEGIN
		        SET @res=1
	        END ELSE
	        BEGIN
		        SET @res=0
	        END
        END
         */
        public Boolean eliminarLogin(Login l)
        {
            Boolean eliminado = false;
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "eliminarLogin";
            SqlParameter parametro1 = new SqlParameter("@idlogin", l.IdLogin);

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
