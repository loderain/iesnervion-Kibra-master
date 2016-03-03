using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*CREATE TABLE DetallesVentas
(
	idDetalles INTEGER IDENTITY,
	precioUnidad MONEY NOT NULL,
	cantidad INTEGER NOT NULL,
	iva INTEGER NOT NULL,
	ordenVenta INTEGER NOT NULL,
	articulo INTEGER NOT NULL,
	CONSTRAINT PK_DetallesVentas PRIMARY KEY (idDetalles),
	CONSTRAINT FK_OrdenesVentas_Detalles FOREIGN KEY (ordenVenta) REFERENCES dbo.OrdenesVentas (idOrdenVenta),
	CONSTRAINT FK_ARTICULOS_DETALLESV FOREIGN KEY (articulo) REFERENCES dbo.Articulos (idArticulo)
)*/

namespace Entidades
{
    public class DetalleVenta
    {
        #region "Campos privados y propiedades públicas"

        private int _IdDetalles;
        public int IdDetalles
        {
            get
            {
                return _IdDetalles;
            }
            set
            {
                _IdDetalles = value;
            }
        }

        private double _PrecioUnidad;
        public double PrecioUnidad
        {
            get
            {
                return _PrecioUnidad;
            }
            set
            {
                _PrecioUnidad = value;
            }
        }

        private int _Cantidad;
        public int Cantidad
        {
            get
            {
                return _Cantidad;
            }
            set
            {
                _Cantidad = value;
            }
        }

        private int _Iva;
        public int Iva
        {
            get
            {
                return _Iva;
            }
            set
            {
                _Iva = value;
            }
        }

        private OrdenVenta _ordenVenta;
        public OrdenVenta ordenVenta
        {
            get
            {
                return _ordenVenta;
            }
            set
            {
                _ordenVenta = value;
            }
        }

        private Articulo _Articulo;
        public Articulo Articulo
        {
            get
            {
                return _Articulo;
            }
            set
            {
                _Articulo = value;
            }
        }

        #endregion

        #region "Constructores"

        public DetalleVenta() { }

        public DetalleVenta(int idDetalles,
                              double precioUnidad,
                              int cantidad,
                              int iva,
                              OrdenVenta ordenVenta,
                              Articulo articulo)
        {
            _IdDetalles = idDetalles;
            _PrecioUnidad = precioUnidad;
            _Cantidad = cantidad;
            _Iva = iva;
            _ordenVenta = ordenVenta;
            _Articulo = articulo;
        }

        #endregion
    }
}