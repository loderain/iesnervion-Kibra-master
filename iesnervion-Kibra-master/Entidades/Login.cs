using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
*/
namespace Entidades
{
    public class Login
    {
        #region "Campos privados y propiedades publicas"

        private int _IdLogin;
        public int IdLogin
        {
            get
            {
                return _IdLogin;
            }

            set
            {
                _IdLogin = value;
            }
        }

        [StringLength(30)]
        private string _Usuario;
        public string Usuario
        {
            get
            {
                return _Usuario;
            }

            set
            {
                _Usuario = value;
            }
        }

        [StringLength(30)]
        private string _Passwd;
        public string Passwd
        {
            get
            {
                return _Passwd;
            }

            set
            {
                _Passwd = value;
            }
        }

        private DateTime _UltimoAcceso;
        public DateTime UltimoAcceso
        {
            get
            {
                return _UltimoAcceso;
            }

            set
            {
                _UltimoAcceso = value;
            }
        }

        private Empleado _Empleado;
        public Empleado Empleado
        {
            get
            {
                return _Empleado;
            }

            set
            {
                _Empleado = value;
            }
        }

        
        private List<Privilegio> _Privilegios;
        public List<Privilegio> Privilegios
        {
            get
            {
                return _Privilegios;
            }

            set
            {
                _Privilegios = value;
            }
        }

        #endregion

        #region "Constructores"

        public Login() { }

        public Login(int IdLogin, string Usuario, string Passwd, DateTime UltimoAcceso, Empleado Empleado)
        {
            _IdLogin = IdLogin;
            _Usuario = Usuario;
            _Passwd = Passwd;
            _UltimoAcceso = UltimoAcceso;
            _Empleado = Empleado;
        }

        #endregion
    }
}

