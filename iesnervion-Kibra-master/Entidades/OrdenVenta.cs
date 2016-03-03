using System;
using System.ComponentModel.DataAnnotations;
using Entidades;
/*
    CREATE TABLE OrdenesVentas(
	    idOrdenVenta INT IDENTITY NOT NULL,
	    fecha DATE not null,
	    empleado INT not null,
	    cliente INT not null,
	    CONSTRAINT PK_idOrdenVenta PRIMARY KEY (idOrdenVenta),
	    CONSTRAINT FK_Empleado_OredenesVentas FOREIGN KEY (empleado) REFERENCES Empleados(idEmpleado),
	    CONSTRAINT FK_Clientes_OrdenesVentas FOREIGN KEY (cliente) REFERENCES Clientes(idCliente)	
    )
*/
namespace Entidades
{
    public class OrdenVenta
    {
        #region "Campos privados y propiedades públicas"

        private int _IdOrdenVenta;
        public int IdOrdenVenta
        {
            get
            {
                return _IdOrdenVenta;
            }

            set
            {
                _IdOrdenVenta = value;
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

        private Cliente _Cliente;
        public Cliente Cliente
        {
            get
            {
                return _Cliente;
            }

            set
            {
                _Cliente = value;
            }
        }

        #endregion

        #region "Constructores"

        public OrdenVenta() { }

        public OrdenVenta(int IdOrdenVenta, DateTime Fecha, Empleado Empleado, Cliente Cliente)
        {
            _IdOrdenVenta = IdOrdenVenta;
            _Fecha = Fecha;
            _Empleado = Empleado;
            _Cliente = Cliente;
        }

        #endregion
    }
}
