using System;
using System.ComponentModel.DataAnnotations;
using Entidades;
/*
    CREATE TABLE Clientes(
	    idCliente INT NOT NULL,
	    nombreCli VARCHAR(80) not null,
	    apellidoCli VARCHAR(80) not null,
	    direccionCli VARCHAR(150) not null,
	    telefonoCli VARCHAR(12) not null,
	    emailCli VARCHAR(150) not null,
	    ciudad INT,
	    CONSTRAINT PK_idCliente PRIMARY KEY (idCliente),
	    CONSTRAINT FK_Ciudades_Clientes FOREIGN KEY(ciudad) REFERENCES Ciudades(idCiudad)
    )
*/
namespace Entidades
{
    public class Cliente
    {
        #region "Campos privados y propiedades públicas"

        private int _IdCliente;
        public int IdCliente
        {
            get
            {
                return _IdCliente;
            }

            set
            {
                _IdCliente = value;
            }
        }

        [StringLength(80)]
        private String _NombreCli;
        public String NombreCli
        {
            get
            {
                return _NombreCli;
            }

            set
            {
                _NombreCli = value;
            }
        }

        [StringLength(80)]
        private String _ApellidoCli;
        public String ApellidoCli
        {
            get
            {
                return _ApellidoCli;
            }

            set
            {
                _ApellidoCli = value;
            }
        }

        [StringLength(150)]
        private String _DireccionCli;
        public String DireccionCli
        {
            get
            {
                return _DireccionCli;
            }

            set
            {
                _DireccionCli = value;
            }
        }

        [StringLength(12)]
        private String _TelefonoCli;
        public String TelefonoCli
        {
            get
            {
                return _TelefonoCli;
            }

            set
            {
                _TelefonoCli = value;
            }
        }

        [StringLength(150)]
        private String _EmailCli;
        public String EmailCli
        {
            get
            {
                return _EmailCli;
            }

            set
            {
                _EmailCli = value;
            }
        }

        private Ciudad _Ciudad;
        public Ciudad Ciudad
        {
            get
            {
                return _Ciudad;
            }

            set
            {
                _Ciudad = value;
            }
        }

        #endregion

        #region "Constructores"
        
        public Cliente() { }

        public Cliente(int IdCliente, String NombreCli, String ApellidoCli, String DireccionCli, String TelefonoCli, String EmailCli, Ciudad Ciudad)
        {
            _IdCliente = IdCliente;
            _NombreCli = NombreCli;
            _ApellidoCli = ApellidoCli;
            _DireccionCli = DireccionCli;
            _TelefonoCli = TelefonoCli;
            _EmailCli = EmailCli;
            _Ciudad = Ciudad;
        }

        #endregion
    }
}
