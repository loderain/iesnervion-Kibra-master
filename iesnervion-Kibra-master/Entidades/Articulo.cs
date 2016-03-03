using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

/*
CREATE TABLE Articulos(
	idArticulo int IDENTITY 
	,nombreArt Varchar(80) NOT NULL
	,imagenArt Binary NOT NULL
	,descArt varchar(150) NOT NULL
	,precioArt money NOT NULL
	,stock int NOT NULL
	,stockMinimo int NOT NULL
	,idProveedor int NOT NULL
*/
namespace Entidades
{
    public class Articulo
    {
        #region "Campos privados y propiedades públicas"

        private int _IdArticulo;
        public int IdArticulo
        {
            get
            {
                return _IdArticulo;
            }

            set
            {
                _IdArticulo = value;
            }
        }

        [StringLength(80)]
        private string _NombreArt;
        public string NombreArt
        {
            get
            {
                return _NombreArt;
            }

            set
            {
                _NombreArt = value;
            }
        }

        private byte[] _ImagenArt;
        public byte[] ImagenArt
        {
            get
            {
                return _ImagenArt;
            }

            set
            {
                _ImagenArt = value;
            }
        }

        [StringLength(150)]
        private string _DescArt;
        public string DescArt
        {
            get
            {
                return _DescArt;
            }

            set
            {
                _DescArt = value;
            }
        }

        private double _PrecioArt;
        public double PrecioArt
        {
            get
            {
                return _PrecioArt;
            }

            set
            {
                _PrecioArt = value;
            }
        }

        private int _Stock;
        public int Stock
        {
            get
            {
                return _Stock;
            }

            set
            {
                _Stock = value;
            }
        }

        private int _StockMinimo;
        public int StockMinimo
        {
            get
            {
                return _StockMinimo;
            }

            set
            {
                _StockMinimo = value;
            }
        }

        private Proveedor _ProveedorArt;
        public Proveedor ProveedorArt
        {
            get
            {
                return _ProveedorArt;
            }

            set
            {
                _ProveedorArt = value;
            }
        }

        #endregion

        #region "Constructores"

        public Articulo() { }

        public Articulo(int idArticulo, string nombreArt, byte[] imagenArt, string descArt, double precioArt, int stock, int stockMin, Proveedor proveedorArt)
        {
            _IdArticulo = idArticulo;
            _NombreArt = nombreArt;
            _ImagenArt = imagenArt;
            _DescArt = descArt;
            _PrecioArt = precioArt;
            _Stock = Stock;
            _StockMinimo = stockMin;
            _ProveedorArt = proveedorArt;
        }

        #endregion
    }
}
