using System;
using System.ComponentModel.DataAnnotations;
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
namespace Entidades
{
    public class Empleado
    {
        #region "Campos privados y propiedades públicas"

        private int _IdEmpleado;
        [Display(Name = "Id")]
        public int IdEmpleado
        {
            get
            {
                return _IdEmpleado;
            }

            set
            {
                _IdEmpleado = value;
            }
        }

        private string _DniEmp;
        [StringLength(9)]
        [Display(Name = "DNI")]
        public string DniEmp
        {
            get
            {
                return _DniEmp;
            }

            set
            {
                _DniEmp = value;
            }
        }

        
        private string _NombreEmp;
        [StringLength(80)]
        [Display(Name = "Nombre")]
        public string NombreEmp
        {
            get
            {
                return _NombreEmp;
            }

            set
            {
                _NombreEmp = value;
            }
        }

        
        private string _ApellidoEmp;
        [StringLength(100)]
        [Display(Name = "Apellidos")]
        public string ApellidoEmp
        {
            get
            {
                return _ApellidoEmp;
            }

            set
            {
                _ApellidoEmp = value;
            }
        }

        private DateTime _FechaNac;
        [Display(Name = "Fecha Nac.")]
        public DateTime FechaNac
        {
            get
            {
                return _FechaNac;
            }

            set
            {
                _FechaNac = value;
            }
        }

        
        private string _DireccionEmp;
        [StringLength(150)]
        [Display(Name = "Dirección")]
        public string DireccionEmp
        {
            get
            {
                return _DireccionEmp;
            }

            set
            {
                _DireccionEmp = value;
            }
        }

        private string _TelefonoEmp;
        [StringLength(12)]
        [Display(Name = "Telefono")]
        public string TelefonoEmp
        {
            get
            {
                return _TelefonoEmp;
            }

            set
            {
                _TelefonoEmp = value;
            }
        }

        
        private string _EmailEmp;
        [StringLength(150)]
        [Display(Name = "Email")]
        public string EmailEmp
        {
            get
            {
                return _EmailEmp;
            }
            set
            {
                _EmailEmp = value;
            }
        }

        private Departamento _DepartamentoEmp;
        [Display(Name = "Departamento")]
        public Departamento DepartamentoEmp
        {
            get
            {
                return _DepartamentoEmp;
            }

            set
            {
                _DepartamentoEmp = value;
            }
        }

        private Puesto _PuestoEmp;
        [Display(Name = "Puesto")]
        public Puesto PuestoEmp
        {
            get
            {
                return _PuestoEmp;
            }

            set
            {
                _PuestoEmp = value;
            }
        }

        private Ciudad _CiudadEmp;
        [Display(Name = "Ciudad")]
        public Ciudad CiudadEmp
        {
            get
            {
                return _CiudadEmp;
            } 

            set
            {
                _CiudadEmp = value;
            }    
        }

        #endregion

        #region "Constructores"

        public Empleado() { }

        public Empleado(int idEmpleado, 
                        string dniEmp, 
                        string nombreEmp, 
                        string apellidoEmp, 
                        DateTime fechaNac, 
                        string direccionEmp, 
                        string telefonoEmp, 
                        string emailEmp, 
                        Departamento departamentoEmp,
                        Puesto puestoEmp,
                        Ciudad ciudadEmp)
        {
            _IdEmpleado = idEmpleado;
            _DniEmp = dniEmp;
            _NombreEmp = nombreEmp;
            _ApellidoEmp = apellidoEmp;
            _FechaNac = fechaNac;
            _DireccionEmp = direccionEmp;
            _TelefonoEmp = telefonoEmp;
            _EmailEmp = emailEmp;
            _DepartamentoEmp = departamentoEmp;
            _PuestoEmp = puestoEmp;
            _CiudadEmp = ciudadEmp;
        }

        #endregion
    }
}
