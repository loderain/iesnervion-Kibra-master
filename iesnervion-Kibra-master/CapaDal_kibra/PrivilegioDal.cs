using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
/*
Create table Privilegios (
	idPrivilegio integer identity,
	nombrePriv varchar(80) not null,
	descPriv varchar(150) not null,
	valorPriv integer not null, 
	CONSTRAINT PK_Privilegios PRIMARY KEY (idPrivilegio)
)
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
    public class PrivilegioDal
    {
        /// <summary>
        /// Devuelve un listado de todos los Privilegios
        /// </summary>
        /// <returns></returns>
        public List<Privilegio> getListaPrivilegios()
        {
            List<Privilegio> listado = new List<Privilegio>();
            DataBaseHelper helper = new DataBaseHelper();
            SqlCommand comando = new SqlCommand("select idprivilegio,nombrepriv,descpriv,valorPriv from Privilegios");
            DataTable datos = helper.getDatos(comando);
            foreach (DataRow row in datos.Rows)
            {
                Privilegio p = new Privilegio(Convert.ToInt32(row[0]), row[1].ToString(), row[2].ToString(), Convert.ToInt32(row[3].ToString()));
                listado.Add(p);
            }

            return listado;
        }

        /// <summary>
        /// devuelve un Privilegio cuyo id es el pasado por parametro
        /// </summary>
        /// <param name="idPrivilegio">id del privilegio a buscar</param>
        /// <returns>Privilegio buscado o null en caso de no existir</returns>
        public Privilegio getPrivilegioPorId(int idPrivilegio)
        {
            Privilegio p = null;
            DataBaseHelper helper = new DataBaseHelper();
            SqlCommand comando = new SqlCommand("select idprivilegio,nombrepriv,descpriv,valorPriv from Privilegios where idprivilegio=@id");
            SqlParameter parameter = new SqlParameter("@id", idPrivilegio);
            parameter.DbType = DbType.Int32;
            comando.Parameters.Add(parameter);
            DataTable datos = helper.getDatos(comando);
            foreach (DataRow row in datos.Rows)
            {
                p = new Privilegio(Convert.ToInt32(row[0]), row[1].ToString(), row[2].ToString(), Convert.ToInt32(row[3].ToString()));

            }

            return p;
        }
        /// <summary>
        /// Metodo que asigna un privilegio a un login
        /// </summary>
        /// <param name="p">privilegio a asignar</param>
        /// <param name="l">login al que se le asignara</param>
        /// <returns>True si pudo asignarse.</returns>
        public Boolean AsignarPrivilegioALogin(Privilegio p, Login l)
        {
            Boolean res = false;
            DataBaseHelper helper = new DataBaseHelper();
            SqlCommand comando = new SqlCommand("insert into Login_Privilegios(idlogin,idprivilegio,fechaAsignado) values(@login,@priv,sysdateTime())");
            SqlParameter param1 = new SqlParameter("@login", l.IdLogin);
            SqlParameter param2 = new SqlParameter("@priv", p.IdPrivilegio);

            res = helper.EjecutaNoQuery(comando);
            return res;
        }

    }
}
