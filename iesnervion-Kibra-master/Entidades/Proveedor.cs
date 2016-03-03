using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
/*
        #region "Campos privados y propiedades publicas"

        #endregion

        #region "Constructores"

        #endregion
    
    CREATE TABLE Proveedores(
	idProveedor int IDENTITY
	,empresaPro Varchar(100) not null
	,nombrePro Varchar(80) not null
	,direccionPro Varchar(150) not null
	,telefonoPro Varchar(12) not null
	,emailPro Varchar(150) not null
	,ciudadPro int not null

*/
namespace Entidades
{
    public class Proveedor
    {
        #region "Campos privados y propiedades publicas"

        private int _IdProveedor;
        public int IdProveedor
        {
            get
            {
                return _IdProveedor;
            }

            set
            {
                _IdProveedor = value;
            }
        }

        [StringLength(100)]
        private string _EmpresaPro;
        public string EmpresaPro
        {
            get
            {
                return _EmpresaPro;
            }

            set
            {
                _EmpresaPro = value;
            }
        }

        [StringLength(80)]
        private string _NombrePro;
        public string NombrePro
        {
            get
            {
                return _NombrePro;
            }

            set
            {
                _NombrePro = value;
            }
        }

        [StringLength(150)]
        private string _DireccionPro;
        public string DireccionPro
        {
            get
            {
                return _DireccionPro;
            }

            set
            {
                _DireccionPro = value;
            }
        }

        [StringLength(12)]
        [DataType(DataType.PhoneNumber)]
        private string _TelefonoPro;
        public string TelefonoPro
        {
            get
            {
                return _TelefonoPro;
            }

            set
            {
                _TelefonoPro = value;
            }
        }

        [StringLength(150)]
        [DataType(DataType.EmailAddress)]
        private string _EmailPro;
        public string EmailPro
        {
            get
            {
                return _EmailPro;
            }

            set
            {
                _EmailPro = value;
            }
        }

        private Ciudad _CiudadPro; 
        public Ciudad CiudadPro
        {
            get
            {
                return _CiudadPro;
            }

            set
            {
                _CiudadPro = value;
            }
        }

        #endregion

        #region "Constructores"

        public Proveedor() { }

        public Proveedor(int idProveedor, string empresaPro, string nombrePro, string direccionPro, string telefonoPro, string emailPro, Ciudad ciudadPro)
        {
            _IdProveedor = idProveedor;
            _EmpresaPro = empresaPro;
            _NombrePro = nombrePro;
            _DireccionPro = direccionPro;
            _TelefonoPro = telefonoPro;
            _EmailPro = emailPro;
            _CiudadPro = ciudadPro;
        }

        #endregion
    }
}
