using System;
using System.ComponentModel.DataAnnotations;
using Entidades;
/*
    CREATE TABLE facturas(
	    idFactura INT IDENTITY NOT NULL,
	    fechaGenerada DATE not null,
	    ordenVenta INT not null,
	    CONSTRAINT PK_Factura PRIMARY KEY (idFactura),
	    CONSTRAINT FK_OrdenesVentas_Facturas FOREIGN KEY (ordenventa) REFERENCES OrdenesVentas (idOrdenVenta)	
    )
*/
namespace Entidades
{
    public class Factura
    {
        #region "Campos privados y propiedades públicas"
        
        private int _IdFactura;
        public int IdFactura
        {
            get
            {
                return _IdFactura;
            }

            set
            {
                _IdFactura = value;
            }
        }

        private DateTime _FechaGenerada;
        public DateTime FechaGenerada
        {
            get
            {
                return _FechaGenerada;
            }

            set
            {
                _FechaGenerada = value;
            }
        }

        private OrdenVenta _OrdenVenta;
        public OrdenVenta OrdenVenta
        {
            get
            {
                return _OrdenVenta;
            }

            set
            {
                _OrdenVenta = value;
            }
        }

        #endregion

        #region "Constructores"

        public Factura() { }

        public Factura(int IdFactura, DateTime FechaGenerada, OrdenVenta OrdenVenta)
        {
            _IdFactura = IdFactura;
            _FechaGenerada = FechaGenerada;
            _OrdenVenta = OrdenVenta;
        }

        #endregion
    }
}
