using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*CREATE TABLE DetallesCompras
(
	idDetalles INTEGER IDENTITY,
	precioUnidad MONEY NOT NULL,
	cantidad INTEGER NOT NULL,
	iva INTEGER NOT NULL,
	ordenCompra INTEGER NOT NULL,
	articulo INTEGER NOT NULL,
	CONSTRAINT PK_DetallesCompras PRIMARY KEY (idDetalles),
	CONSTRAINT FK_OrdenesCompras_Detalles FOREIGN KEY (ordenCompra) REFERENCES dbo.OrdenesCompras (idOrdenCompra),
	CONSTRAINT FK_ARTICULOS_DETALLESC FOREIGN KEY (articulo) REFERENCES dbo.Articulos (idArticulo)
)*/

namespace Entidades
{
    public class DetalleCompra
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

        private OrdenCompra _OrdenCompra;
        public OrdenCompra OrdenCompra
        {
            get
            {
                return _OrdenCompra;
            }
            set
            {
                _OrdenCompra = value;
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

        public DetalleCompra() { }

        public DetalleCompra(int idDetalles,
                              double precioUnidad,
                              int cantidad,
                              int iva,
                              OrdenCompra ordenCompra,
                              Articulo articulo)
        {
            _IdDetalles = idDetalles;
            _PrecioUnidad = precioUnidad;
            _Cantidad = cantidad;
            _Iva = iva;
            _OrdenCompra = ordenCompra;
            _Articulo = articulo;
        }

        #endregion
    }
}