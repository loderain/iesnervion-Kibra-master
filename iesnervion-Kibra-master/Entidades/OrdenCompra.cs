using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*CREATE TABLE OrdenesCompras
(
	idOrdenCompra INTEGER IDENTITY,
	fecha DATE NOT NULL,
	empleado INTEGER NOT NULL,
	proveedor INTEGER NOT NULL,
	CONSTRAINT PK_OrdenesCompras PRIMARY KEY (idOrdenCompra),
	CONSTRAINT FK_Empleados_OrdenesCompras FOREIGN KEY (empleado) REFERENCES dbo.Empleados (idEmpleado),
	CONSTRAINT FK_Proveedores_OrdenesCompras FOREIGN KEY (proveedor) REFERENCES dbo.Proveedores (idProveedor)
)*/

namespace Entidades
{
    public class OrdenCompra
    {
        #region "Campos privados y propiedades públicas"

        private int _IdOrdenCompra;
        public int IdOrdenCompra
        {
            get
            {
                return _IdOrdenCompra;
            }
            set
            {
                _IdOrdenCompra = value;
            }
        }

        private DateTime _Fecha;
        public DateTime Fecha
        {
            get
            {
                return _Fecha;
            }
            set
            {
                _Fecha = value;
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

        private Proveedor _Proveedor;
        public Proveedor Proveedor
        {
            get
            {
                return _Proveedor;
            }
            set
            {
                _Proveedor = value;
            }
        }
        #endregion

        #region "Constructores"

        public OrdenCompra() { }

        public OrdenCompra(int idOrdenCompra,
                              DateTime fecha,
                              Empleado empleado,
                              Proveedor proveedor)
        {
            _IdOrdenCompra = idOrdenCompra;
            _Fecha = fecha;
            _Empleado = empleado;
            _Proveedor = proveedor;
        }

        #endregion
    }
}